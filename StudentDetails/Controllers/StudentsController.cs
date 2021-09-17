using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDetails.Common;
using StudentsProject.Business;
using StudentsProject.Models;
using System;

namespace StudentsProject.Controllers
{
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private readonly IStudentBusiness _studentBusiness;
        private readonly ILogger<StudentsController> _ilogger;

        public StudentsController(IStudentBusiness studentBusiness, ILogger<StudentsController> ilogger)
        {
            _studentBusiness = studentBusiness;
            _ilogger = ilogger;
        }

        /// <summary>
        /// Method to create Student
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent([FromBody]StudentDto studentDto)
        {
            _ilogger.LogDebug("Create Student API Started : CreateStudent");
            try
            {
                if(!ModelState.IsValid)
                {
                    return StatusCode(Constants.BadRequest,Constants.InputInvalid);
                }

                var result = _studentBusiness.CreateStudent(studentDto);
                if (result)
                    _ilogger.LogDebug("Response : True");
                else
                    _ilogger.LogDebug("Response : False");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _ilogger.LogError("Error Message for Create Student" + ex.Message);
                return StatusCode(Constants.Exception, ex);
            }
        }

        /// <summary>
        /// UpdateStudent Method
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns>true</returns>
        [HttpPost("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody]StudentDto studentDto)
        {
            _ilogger.LogDebug("API Started : UpdateStudent");
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(Constants.BadRequest, Constants.InputInvalid);
                }

                var result = _studentBusiness.UpdateStudent(studentDto);
                if (result)
                    _ilogger.LogDebug("Response : True");
                else
                    _ilogger.LogDebug("Response : False");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _ilogger.LogError("Log Error Message for Update Student" + ex.Message);
                _ilogger.LogError(ex.Message);
                return StatusCode(Constants.Exception, ex);
            }
        }

        /// <summary>
        /// Get Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetStudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var data = _studentBusiness.GetStudentById(id);

                if (data == null)
                    _ilogger.LogDebug("Response : True");
                else
                    _ilogger.LogDebug("Response : False");

                return Ok(data);
            }
            catch (Exception ex)
            {
                _ilogger.LogError("Log Error Message for Get Student By Id" + ex.Message);
                _ilogger.LogError(ex.Message);
                return StatusCode(Constants.Exception, ex);
            }
        }

        /// <summary>
        /// Delete Student By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var result = _studentBusiness.DeleteStudent(id);

                if (result)
                    _ilogger.LogDebug("Response : True");
                else
                    _ilogger.LogDebug("Response : False");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                _ilogger.LogError("Error Message for Delete Student Based on Id" + ex.Message);
                return StatusCode(Constants.Exception, ex);
            }
        }
        /// <summary>
        /// Get the List of Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var result = _studentBusiness.GetAllStudents();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _ilogger.LogError(ex.Message);
                _ilogger.LogError("Error Message for Get All Students" + ex.Message);
                return StatusCode(Constants.Exception, ex);
            }
        }

    }
}
