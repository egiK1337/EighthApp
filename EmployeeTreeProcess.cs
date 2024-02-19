
namespace EighthApp
{
    public class EmployeeTreeProcess
    {
        public static EmployeeTree InputNode()
        {
            EmployeeTree root = null;
            while (true)
            {
                Console.WriteLine("Для остановки ввода введите пустую строку");
                Console.WriteLine("Введите имя сотрудника");

                var name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Вы ввели пустую строку ввод остановлен");
                    break;
                }

                Console.WriteLine("Введите зарплату сотрудника");
                var salary = Console.ReadLine();
                var salaryCheck = int.TryParse(salary, out var salaryToInt);

                if(salaryCheck != false)
                {
                    if (salaryToInt == 0)
                    {
                        Console.WriteLine("Вы ввели пустую строку ввод остановлен");
                        break;
                    }
                }
               
                if (root == null)
                {
                    root = new EmployeeTree()
                    {
                        Name = name,
                        Salary = salaryToInt,
                        Left = null,
                        Right = null
                    };
                }
                else
                {
                    AddNode(root, new EmployeeTree()
                    {
                        Name = name,
                        Salary = salaryToInt
                    });
                }
            }
            return root;
        }

        public static void AddNode(EmployeeTree rootNode, EmployeeTree nodeToAdd)
        {
            if (nodeToAdd.Salary < rootNode.Salary)
            {
                if (rootNode.Left != null)
                {
                    AddNode(rootNode.Left, nodeToAdd);
                }
                else
                {
                    rootNode.Left = nodeToAdd;
                }
            }
            else
            {
                if (rootNode.Right != null)
                {
                    AddNode(rootNode.Right, nodeToAdd);
                }
                else
                {
                    rootNode.Right = nodeToAdd;
                }
            }
        }

        public static void MakeTreeTraverse(EmployeeTree tree)
        {
            if(tree != null)
            {
                if (tree.Left != null && tree.Left.Name != "")
                {
                    MakeTreeTraverse(tree.Left);
                }

                Console.WriteLine($"Имя сотрудника:{tree.Name};Зарплата:{tree.Salary}");

                if (tree.Right != null && tree.Right.Name != "")
                {
                    MakeTreeTraverse(tree.Right);
                }
            }    
        }

        public static void FindEmployeeSalary(EmployeeTree root)
        {
            Console.WriteLine("Введите зарплату сотрудника для его поиска");           
            while (true)
            {
                var salaryString = Console.ReadLine();
                var salaryCheck = int.TryParse(salaryString, out var salary);
                if(salaryCheck != false)
                {
                    if (salary == 0)
                    {
                        break;
                    }
                }
               
                var node = FindEmployeeSalary(root, salary, count: 0);

                if (node != null)
                {
                    Console.WriteLine($"Найден сотрудник: {node.Name}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Такой сотрудник не найден");
                    break;
                }
            }

        }

        public static EmployeeTree FindEmployeeSalary(EmployeeTree root,int salary, int count)
        {
            if(root != null) 
            {
                if (salary < root.Salary)
                {
                    if (root.Left != null)
                    {
                        return FindEmployeeSalary(root.Left, salary, count + 1);
                    }
                    return null;
                }
                if (salary > root.Salary)
                {
                    if (root.Right != null)
                    {
                        return FindEmployeeSalary(root.Right, salary, count + 1);
                    }
                    return null;
                }               
            }
            return root;
        }
    }
}
