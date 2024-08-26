using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using VCardQr.Data;
using VCardQr.Models;

namespace VCardQr.Controllers;

public class VCardController : Controller
{
    private readonly VCardQrDbContext _dbContext;

    public VCardController(VCardQrDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Index(VCard model)
    {
        if (ModelState.IsValid)
        {
            var vCard = new VCard
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Phone = model.Phone,
                Fax = model.Fax,
                Email = model.Email,
                Company = model.Company,
                Job = model.Job,    
                Street = model.Street,  
                City = model.City,
                Country = model.Country
            };

            return RedirectToAction("GenerateQr", vCard);
        }

        return View(model);
    }



    public IActionResult GenerateQr(VCard model)
    {
        QRCodeLogo qrCode = new QRCodeLogo();
        GeneratedBarcode qrCodeWithLogo = QRCodeWriter.CreateQrCodeWithLogo(model.GenerateVCard(), qrCode);

        string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string images = Path.Combine(root, "assets", "images");

        if (!Directory.Exists(images))
        {
            Directory.CreateDirectory(images);
        }

        string fileName = $"{model.Id}.jpg";
        string filePath = Path.Combine(images, fileName);

        qrCodeWithLogo.SaveAsImage(filePath);

        model.QrCode = $"/assets/images/{fileName}";

        _dbContext.VCards.Add(model);
        _dbContext.SaveChanges();

        return View(model);
    }




}
