
namespace EighthApp
{
    public class Program
    {
        static void Main()
        {

            while (true)
            {
                var status = false;

                var tree = EmployeeTreeProcess.InputNode();               
               
                if (tree != null)
                {
                    EmployeeTreeProcess.MakeTreeTraverse(tree);
                    EmployeeTreeProcess.FindEmployeeSalary(tree);
                }

                while (true)
                {
                    Console.WriteLine("Для построения нового списка сотрудников введите 0, для повторного поиска в существующем списке введите 1, для выхода введите -1");

                    var enterCommand = Console.ReadLine();
                    var command = int.TryParse(enterCommand, out var result);

                    if (command == true)
                    {
                        if (result == 0)
                        {
                            var newTree = EmployeeTreeProcess.InputNode();
                            EmployeeTreeProcess.MakeTreeTraverse(newTree);
                            EmployeeTreeProcess.FindEmployeeSalary(newTree);
                            tree = newTree;
                        }

                        if (result == 1)
                        {
                            if (tree.Name != null || tree.Salary != null)
                            {
                                EmployeeTreeProcess.FindEmployeeSalary(tree);
                            }
                        }

                        if (result == -1)
                        {
                            status = true;
                            break;
                        }
                    }
                }
                if(status == true)
                {
                    break;
                }
            }
        }
    }
}