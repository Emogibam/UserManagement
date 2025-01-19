using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserManagement.Shared;

namespace UserManagement.Application.Helpers
{
    public class ValidationHelperService
    {
        private const int OkCode = 200;
        private const int BadRequestCode = 400;
        private const string CreatedMessage = "Request created successfully.";
        private const string UpdatedMessage = "Request updated successfully.";
        private const string DeletedMessage = "Request deleted successfully.";
        private const string NotFoundMessage = "Record not found";
        private const string InternalServerErrorMessage = "Error: Something wrong, please contact the site administrator.";
        public async Task<GenericResponse<string>> ValidateAlphabeticString(string _value)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(_value))
            {
                return GenericResponse<string>.BadRequest("Only alphabets are allowed.");
            }

            return GenericResponse<string>.Success(_value, CreatedMessage);
        }

        public async Task<GenericResponse<string>> ValidatePassword(string password, string confirmPassword)
        {
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit) || !password.Any(x => !char.IsLetterOrDigit(x)) || password.Length < 8)
            {
                return GenericResponse<string>.BadRequest("Minimum of 8 characters which includes at least an uppercase letter, a lowercase letter, a digit, and a special character.");
            }

            if (!password.Equals(confirmPassword))
            {
                return GenericResponse<string>.BadRequest("Passwords do not match.");
            }

            return GenericResponse<string>.Success(password, CreatedMessage);
        }

        public async Task<GenericResponse<string>> ValidatePassword(string password)
        {
            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit) || !password.Any(x => !char.IsLetterOrDigit(x)) || password.Length < 8)
            {
                return GenericResponse<string>.BadRequest("Minimum of 8 characters which includes at least an uppercase letter, a lowercase letter, a digit, and a special character.");
            }

            return GenericResponse<string>.Success(password, CreatedMessage);
        }

        public async Task<GenericResponse<string>> ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(email))
            {
                return GenericResponse<string>.BadRequest("The provided email address is not valid. Please use a format like example@domain.com.");
            }

            const string successMessage = "The email address is valid.";
            return GenericResponse<string>.Success(email, successMessage);
        }

        //public async Task<GenericResponse<DateRangeDTO>> ValidateDateRange(string startDate, string endDate)
        //{
        //    CultureInfo provider = CultureInfo.InvariantCulture;

        //    string[] format = new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "yyyy/MM/dd", "yyyy-MM-dd" };
        //    DateTime _startDate = DateTime.ParseExact(startDate, format, provider, DateTimeStyles.None);
        //    DateTime _endDate = DateTime.ParseExact(endDate, format, provider, DateTimeStyles.None);
        //    var today = DateTime.UtcNow.AddHours(1);

        //    if (_startDate > today)
        //    {
        //        return GenericResponse<DateRangeDTO>.BadRequest("StartDate cannot be greater than today's date.");
        //    }

        //    if (_endDate > today)
        //    {
        //        return GenericResponse<DateRangeDTO>.BadRequest("EndDate cannot be greater than today's date.");
        //    }

        //    if (_startDate > _endDate)
        //    {
        //        return GenericResponse<DateRangeDTO>.BadRequest("StartDate cannot be greater than EndDate.");
        //    }

        //    DateRangeDTO dateRangeDTO = new DateRangeDTO()
        //    {
        //        StartDate = _startDate,
        //        EndDate = _endDate,
        //    };

        //    return GenericResponse<DateRangeDTO>.Success(dateRangeDTO, CreatedMessage);
        //}

        //public async Task<GenericResponse<DateRangeDTO>> ValidateDateRangeWithoutEndDate(string startDate, string endDate)
        //{
        //    CultureInfo provider = CultureInfo.InvariantCulture;

        //    string[] format = new string[] { "dd/MM/yyyy", "dd-MM-yyyy", "yyyy/MM/dd", "yyyy-MM-dd" };
        //    DateTime _startDate = DateTime.ParseExact(startDate, format, provider, DateTimeStyles.None);
        //    DateTime _endDate = DateTime.ParseExact(endDate, format, provider, DateTimeStyles.None);
        //    var today = DateTime.UtcNow.AddHours(1);

        //    if (_startDate > today)
        //    {
        //        return GenericResponse<DateRangeDTO>.BadRequest("StartDate cannot be greater than today's date.");
        //    }

        //    if (_startDate > _endDate)
        //    {
        //        return GenericResponse<DateRangeDTO>.BadRequest("StartDate cannot be greater than EndDate.");
        //    }

        //    DateRangeDTO dateRangeDTO = new DateRangeDTO()
        //    {
        //        StartDate = _startDate,
        //        EndDate = _endDate,
        //    };

        //    return GenericResponse<DateRangeDTO>.Success(dateRangeDTO, CreatedMessage);
        //}
    }
}
