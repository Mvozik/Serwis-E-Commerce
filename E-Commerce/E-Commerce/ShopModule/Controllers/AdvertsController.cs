using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using Mapster;
using E_Commerce.ShopModule.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using E_Commerce.ShopModule.Dtos.AdvertDtos;
using Microsoft.AspNetCore.Builder;
using System.IO;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace E_Commerce.ShopModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        public AdvertsController(DataContext context, IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAdverts()
        {

            var response = await _advertService.GetAdvertsAsync();
            return Ok(response.Adapt<List<GetAdvertsDto>>());

        }

        [HttpGet]
        public async Task<IActionResult> GetAdvert(int id)
        {
            var response = await _advertService.GetAdvertByIdAsync(id);
            return Ok(response.Adapt<GetAdvertsDto>());
        }


        [HttpPut]
        public async Task<IActionResult> PutAdvert(PutAdvertDto advert)
        {
            var response = await _advertService.UpdateAdvertAsync(advert);
            if (response.Success == false)
            {
                return BadRequest(new OperationFailedResponse { Errors = response.Errors });
            }
            return Ok(response.Id);
        }

        [HttpPost]
        public async Task<IActionResult> PostAdvert(PostAdvertDto postAdvertDto)
        {
            var response = await _advertService.PostAdvertAsync(postAdvertDto);
            if(response.Success==false)
            {
                return BadRequest(new OperationFailedResponse { Errors = response.Errors });
            }
            var file = Request.Form.Files[0];

            var folderName = Path.Combine("Resources", "Images");

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                PutAdvertDto putAdvertDto = postAdvertDto.Adapt<PutAdvertDto>();

                putAdvertDto.PhotoFullPath = dbPath;

                await _advertService.UpdateAdvertAsync(putAdvertDto);

                return Ok(response.Id);
            }
            else
            {
                return BadRequest();
            }

            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdvert(int id)
        {
            var response = await _advertService.DeleteAdvertByIdAsync(id);
            if(response.Success==false)
            {
                return BadRequest(new OperationFailedResponse { Errors = response.Errors });
            }
            return Ok(response.Id);
        }

    }
}
