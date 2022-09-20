using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swift.BBS.IServices;
using Swift.BBS.Model.Models;
using Swift.BBS.Model.Viewmodels;
using Swift.BBS.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Swift.BBS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScanController : ControllerBase
    {
        private readonly IImageService imagesService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;


        public ScanController(IImageService _imageService,IMapper _impper, IWebHostEnvironment _webHostEnvironment) {
            this.imagesService = _imageService;
            this.mapper = _impper;
            this.webHostEnvironment = _webHostEnvironment;
        }


        /// <summary>
        /// 创建图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> CreateImages(ImagesDto input)
        {


            var entity = mapper.Map<Images>(input);
            entity.CreateTime = DateTime.Now;
            //entity.CreateUserId = 3;
            await imagesService.InsertAsync(entity, true);

            return new MessageModel<string>()
            {
                success = true,
                msg = "创建成功"
            };
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        [HttpPost]
        public String UpdateImg(IFormFile file) {         
                string directory = Path.Combine(webHostEnvironment.ContentRootPath, "Images");
                string fileExtension = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtension;
                string filePath = Path.Combine(directory, fileName);
                // 生成文件路径
                while (System.IO.File.Exists(filePath))
                {
                    fileName = Guid.NewGuid().ToString() + fileExtension;
                    filePath = Path.Combine(directory, fileName);
                }
                // 写入文件
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
            
            return JsonConvert.SerializeObject(new
            {
                code = 0,
                msg = "",
                data = ""
            });



        }



    }
}
