using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SampleMvcApp.KMS;
using System;

namespace SampleMvcApp.Controllers
{
    public class ApiDataController : Controller
    {
        private readonly ApiService _apiService;
        private readonly DecryptDataExample _decryptor;

        public ApiDataController(ApiService apiService, DecryptDataExample decryptor)
        {
            _apiService = apiService;
            _decryptor = decryptor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetEncryptedData()
        {
            try
            {
                var data = await _apiService.GetDataAsync();
                return Json(new { success = true, data });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DecryptData(string base64Ciphertext)
        {
            try
            {
                string decryptedData = _decryptor.DecryptSymmetric(base64Ciphertext);
                return Json(new { success = true, decryptedData });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
