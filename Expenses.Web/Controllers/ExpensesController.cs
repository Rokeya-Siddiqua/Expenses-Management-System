using Expenses.DataAccess.Repositories;
using Expenses.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _expensesRepository;

        public ExpensesController(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public IActionResult Index(string searching)
        {
            List<ExpenseModel> lists = new List<ExpenseModel>();

            if (string.IsNullOrEmpty(searching)) {
                lists = _expensesRepository.GetAllExpenses().ToList();
            }
            else
            {
                lists = _expensesRepository.Search(searching).ToList();
            }
            return View(lists);
        }
    }
}
