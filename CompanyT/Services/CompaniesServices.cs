using CompanyT.Models;

namespace CompanyT.Services
{
    public static class CompaniesServices
    {
        /// <summary>
        /// Получаем список компаний, если меньше 5 в БД, добавляем 10 тестовых
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Company> GetCompanies(ApplicationContext context)
        {
            List<Company> companies = new List<Company>();
            try
            {
                companies = (from c in context.Companies
                             orderby c.Name
                             select c).ToList();
            }
            catch (Exception ex) { }
            if (companies.Count < 5) companies = CreateTestList(companies);
            return companies;
        }
        /// <summary>
        /// Добавление компании
        /// </summary>
        /// <param name="company"></param>
        /// <param name="context"></param>
        public static void AddCompany(Company company, ApplicationContext context)
        {
            context.Companies.Update(company);
            context.SaveChanges();
        }

        /// <summary>
        /// Удаляем компaнию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        public static void DeleteCompany(int id, ApplicationContext context)
        {
            Company company = (from c in context.Companies
                               where (c.Id == id)
                               select c).FirstOrDefault();
            if (company != null) context.Companies.Remove(company);
            context.SaveChanges();
        }
        /// <summary>
        /// получаем компанию по ИД, не безопасный метод
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Company GetCompanyById(int id, ApplicationContext context)
        {
            Company company = (from c in context.Companies
                               where (c.Id == id)
                               select c).FirstOrDefault();
            return company;
        }

        /// <summary>
        ///  Тестовые записи
        /// </summary>
        /// <param name="companiesList"></param>
        /// <returns></returns>
        static List<Company> CreateTestList(List<Company> companiesList)
        {
            for (int i = 0; i < 10; i++)
            {
                Company company = new Company();
                company.Name = "Company" + i.ToString();
                company.State = "State" + i.ToString();
                company.Adress = "Street" + i.ToString();
                company.City = "City" + i.ToString();
                company.Phone = i + 10000000;
                companiesList.Add(company);
            }

            return companiesList;
        }
    }
}
