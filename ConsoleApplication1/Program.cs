using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Experience exp = new Experience
            //{
            //    id = 10,
            //    from = new DateTime(),
            //    to = new DateTime(),
            //    poste = "engineer",
            //    company = "Vermeg"
            //};
            //Organisation org = new Organisation
            //{
            //    City = "Monastir",
            //    Country = "Tunisia",
            //    Name = "ISIMM"
            //};

            //Education educ = new Education
            //{
            //    id = 10,
            //    from = new DateTime(),
            //    to = new DateTime(),
            //    organisation = org,
            //};
            //Address adr = new Address
            //{
            //    address = "C5 , C6 N°2 ",
            //    city = "Monastir",
            //    country = "Tunisia"
            //};
            //Candidate cand = new Candidate
            //{
            //    id=10,
            //    address = adr,
            //    age = 24,
            //    birthDate = new DateTime(),
            //    email = "ala.benkhlifa@esprit.tn",
            //    name = "Ala",
            //    phone = "50280400",
            //    sex = "Male",
            //    surname = "Ben khlifa"
            //};
            //var listedu = new Education[10];
            //CVService CVS = new CVService();
            //CV c = CVS.GetById(2);
            //EducationService ES = new EducationService();
            //listedu = c.educations.ToArray();
            //Console.WriteLine(ES.GetById(listedu[0].id).title);
            //var listexp = new List<Experience>();
            //var listlang = new List<Languages>();
            //listlang.Add(lang);
            //listexp.Add(exp);
            //listedu.Add(educ);

            //CV cv = new CV
            //{

            //    candidate = cand,
            //    departement = "RH",
            //    educations = listedu,
            //    experiences = listexp,
            //    hobbies = "FootBall",
            //    languages = listlang,
            //    linkedInLink = "URL",
            //    typeofjob = "Engineer"

            //};
            //Languages lang = new Languages
            //{

            //    level = "Native",
            //    name = "AR",
            //    cv = cv
            //};
            //LanguageService LS = new LanguageService();
            //LS.Add(lang);
            //LS.Commit();
            //ExperienceService ES = new ExperienceService();
            //ES.Add(exp);
            //ES.Commit();
            //EducationService EDS = new EducationService();
            //EDS.Add(educ);
            //EDS.Commit();

            //var con = CAS.GetById(2);
            //Console.WriteLine(con.email);

            //CAS.Add(cand);
            //CAS.Commit();
            //CVService CVS = new CVService();
            //CVS.Add(cv);
            //CVS.Commit();
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create
            //("http://127.0.0.1:18080/pidev-web/api/users/auth");
            //request.ContentType = "application/json";
            //request.Method = "POST";

            //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    string json = "{\"username\":\"admin\",\"password\":\"1234\"}";

            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            //string content = "";            
            //try
            //{
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //    Stream stream = response.GetResponseStream();
            //    StreamReader sr = new StreamReader(stream);
            //    content = sr.ReadToEnd();
            //}
            //catch(WebException WE)
            //{
            //content = "Failed";
            //}

            //var releases = JObject.Parse(content);

           
            Console.ReadKey();
        }
    }
}
