using System.Reflection;
using FluentValidation;
using ProductClient.Exceptions.ExceptionsBase;
#nullable disable

namespace ProductClient.API.Validations;
public static class Validator<T>
{
    public static void ExecuteValidation(T Entity)
    {
        var validatorType = Assembly.GetExecutingAssembly().GetTypes()
                            .FirstOrDefault(t => t.BaseType != null &&
                                                 t.BaseType.IsGenericType &&
                                                 t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>) &&
                                                 t.BaseType.GetGenericArguments()[0] == typeof(T));

        var validator = (IValidator<T>)Activator.CreateInstance(validatorType);
        var validationResult = validator.Validate(Entity);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(erros => erros.ErrorMessage).ToList();
            throw new ExceptionValidation(errors);
        }
    }
}
