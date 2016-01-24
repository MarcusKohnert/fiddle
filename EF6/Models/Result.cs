using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Result<T> : IResult<T>
    {
        private IList<string> errors;

        public Result(T entity, IList<string> errors)
        {
            this.errors = errors;
        }

        public T Entity { get; private set; }

        public bool Succeeded => this.errors.Any();

        public static IResult<T> Ok(T entity)
        {
            return new Result<T>(entity, Array.Empty<string>());
        }
    }
}