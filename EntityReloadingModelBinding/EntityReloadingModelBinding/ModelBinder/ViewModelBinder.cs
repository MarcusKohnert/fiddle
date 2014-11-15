using EntityReloadingModelBinding.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EntityReloadingModelBinding.ModelBinder
{
    public class ViewModelBinder<TEntity> : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,
                                         ModelBindingContext bindingContext)
        {
            TEntity entity = default(TEntity);

            var maybeId = this.TryGetIdentifier(controllerContext, bindingContext);
            if (maybeId.Item1)
            {
                var repo = new Repo();
                entity = repo.Get<TEntity>(maybeId.Item2);
            }
            else
            {
                var entityType = bindingContext.ModelType
                                               .GetProperty("Entity")
                                               .PropertyType;

                entity = (TEntity)Activator.CreateInstance(entityType);
            }

            bindingContext.ModelMetadata.Model = Activator.CreateInstance(bindingContext.ModelType, entity);
            return base.BindModel(controllerContext, bindingContext);
        }

        protected virtual Tuple<bool, int> TryGetIdentifier(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value_Id = bindingContext.ValueProvider.GetValue("Id");
            var value_id = bindingContext.ValueProvider.GetValue("id");

            if (value_Id == null && value_id == null) return Tuple.Create(false, 0);

            if (value_Id != null &&
                value_id != null &&
                value_Id.AttemptedValue.Equals(value_Id.AttemptedValue, StringComparison.OrdinalIgnoreCase))
            {
                // TODO: set invalid model state
            }

            int id = 0;

            if((value_Id != null && int.TryParse(value_Id.AttemptedValue, out id)) ||
                value_id != null && int.TryParse(value_id.AttemptedValue, out id))
                return Tuple.Create(true, id);
            else
                return Tuple.Create(false, id);
        }
    }
}