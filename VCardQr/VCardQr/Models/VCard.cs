namespace VCardQr.Models;

public class VCard
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Mobile { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string Email { get; set; } = null!;
    public string? Company { get; set; }
    public string? Job { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? QrCode { get; set; }


    public string GenerateVCard()
    {

        #region Old
        //var vc = new StringBuilder();
        //vc.AppendLine("BEGIN:VCARD");
        //vc.AppendLine("VERSION:3.0");
        //vc.AppendLine($"FN:{vcard.FirstName} {vcard.LastName}");
        //vc.AppendLine($"N:{vcard.LastName};{vcard.FirstName};;;");
        //vc.AppendLine($"ORG:{vcard.Company}");
        //vc.AppendLine($"TITLE:{vcard.Job}");
        //vc.AppendLine($"TEL;TYPE=CELL:{vcard.Mobile}");
        //vc.AppendLine($"TEL;TYPE=WORK,VOICE:{vcard.Phone}");
        //vc.AppendLine($"TEL;TYPE=FAX:{vcard.Fax}");
        //vc.AppendLine($"EMAIL;TYPE=PREF,INTERNET:{vcard.Email}");
        //vc.AppendLine($"ADR;TYPE=WORK:;;{vcard.Street};{vcard.State};{vcard.Zip};{vcard.Country}");
        //vc.AppendLine($"URL:{vcard.Website}");
        //vc.AppendLine("END:VCARD");

        //return vc.ToString(); 
        #endregion
        return $@"BEGIN:VCARD
            VERSION:3.0
            N:{FirstName}
            FN:{LastName}
            EMAIL:{Email}
            TEL;TYPE=CELL:{Mobile}
            TEL;TYPE=WORK,VOICE:{Phone}
            ORG:{Company}
            TITLE:{Job}
            TEL;TYPE=FAX:{Fax}
            ADR;TYPE=WORK:;;{Street};{City};{Country}
            END:VCARD".Trim();

    }
}
