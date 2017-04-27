using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSCCModelDB;
using System.Data.Entity; //entity framework
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace NSCCConsoleApp
{
    public class ProgramApp
    {
        public static void Main(string[] args)
        {
            //NSCCDBContext context = new NSCCDBContext();
            Database.SetInitializer(new NSCCDatabaseInitializer());

            using (var context = new NSCCDBContext())
            {
                try
                {
                    
                    Citizenship newCitizenship = new Citizenship();
                    newCitizenship.Description = "Alien from Outerspace";
                    context.Citizenships.Add(newCitizenship);
                    context.SaveChanges();
                    
                    Applicant newApplicant = new Applicant();
                    newApplicant.FirstName = "Ryan";
                    newApplicant.MiddleName = "John";
                    newApplicant.LastName = "Sutcliffe";
                    newApplicant.DOB = DateTime.Now;
                    newApplicant.Gender = "M";
                    newApplicant.StreetAddress1 = "1 Halifax Drive";
                    newApplicant.City = "Halifax";
                    newApplicant.CountryCode = "CA";
                    newApplicant.PhoneHome = "5555555555";
                    newApplicant.Email = "ryan@email.com";
                    newApplicant.Citizenship = 1;
                    newApplicant.Password = "passwprd";
                    context.Applicants.Add(newApplicant);
                    context.SaveChanges();

                    Application app = new Application();
                    app.ApplicationDate = DateTime.Now;
                    app.ApplicantId = 1;
                    app.ApplicationFee = 1000;
                    app.Paid = false;

                    context.Applications.Add(app);
                    context.SaveChanges();

                    // catch(DbUpdateException e)
                    //{
                    //     Console.WriteLine(e.Message);
                    //}

                    /*
                    if (!context.Database.Exists())
                    {
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                    */
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    
                    Console.Write(e.InnerException.ToString());
                    
                    Console.ReadKey();
                }


            }
        }
    }
}
