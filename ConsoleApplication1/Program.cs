using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Experience exp = new Experience
            {
                id = 10,
                from = new DateTime(),
                to = new DateTime(),
                poste = "engineer",
                company = "Vermeg"
            };
            Organisation org = new Organisation
            {
                organisationCity = "Monastir",
                organisationCountry = "Tunisia",
                organisationName = "ISIMM"
            };

            Education educ = new Education
            {
                id = 10,
                from = new DateTime(),
                to = new DateTime(),
                organisation = org,
            };
            Address adr = new Address
            {
                address = "C5 , C6 N°2 ",
                city = "Monastir",
                country = "Tunisia"
            };
            Candidate cand = new Candidate
            {
                id=10,
                address = adr,
                age = 24,
                birthDate = new DateTime(),
                email = "ala.benkhlifa@esprit.tn",
                name = "Ala",
                phone = "50280400",
                sex = "Male",
                surname = "Ben khlifa"
            };
            var listedu = new List<Education>();
            var listexp = new List<Experience>();
            var listlang = new List<Languages>();
            //listlang.Add(lang);
            //listexp.Add(exp);
            //listedu.Add(educ);
            
            CV cv = new CV
            {
               
                candidate = cand,
                departement = "RH",
                educations = listedu,
                experiences = listexp,
                hobbies = "FootBall",
                languages = listlang,
                linkedInLink = "URL",
                typeofjob = "Engineer"
                
            };
            Languages lang = new Languages
            {

                level = "Native",
                name = "AR",
                cv = cv
            };
            //LanguageService LS = new LanguageService();
            //LS.Add(lang);
            //LS.Commit();
            //ExperienceService ES = new ExperienceService();
            //ES.Add(exp);
            //ES.Commit();
            //EducationService EDS = new EducationService();
            //EDS.Add(educ);
            //EDS.Commit();
            CandidateService CAS = new CandidateService();
            //var con = CAS.GetById(2);
            //Console.WriteLine(con.email);
            //CAS.Add(cand);
            //CAS.Commit();
            //CVService CVS = new CVService();
            //CVS.Add(cv);
            //CVS.Commit();
            Console.ReadKey();
        }
    }
}
