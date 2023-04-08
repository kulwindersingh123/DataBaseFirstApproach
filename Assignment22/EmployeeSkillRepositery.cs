using Assignment22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment22
{
    public class EmployeeSkillRepositery
    {
        public static void ShowEmployeeSkillTable() 
        {
            CompanyContext employeeSkillcontext = new CompanyContext();

            List<EmployeeSkill> employeeSkills = employeeSkillcontext.EmployeeSkill.ToList();
            foreach (EmployeeSkill employeeSkillData in employeeSkills)
            {
                Console.WriteLine("Id={0} | EmployeeId:{1} | SkillId:{2}",
               employeeSkillData.Id, employeeSkillData.EmployeeId, employeeSkillData.Skill_ID);
            }

        }
        public static void InsertEmployeeSkill()
        {
            CompanyContext employeeSkillcontext = new CompanyContext();

            Console.WriteLine("Enter employeeSkill ID:");
            int.TryParse(Console.ReadLine(), out int idOfSkillGivenByUser);

            
            if (employeeSkillcontext.EmployeeSkill.Find(idOfSkillGivenByUser) != null )
            {
                Console.WriteLine("Sorry,this employee skill is already present in Table");

            }
            else
            {
                Console.WriteLine("Enter Employee Id:");
                int.TryParse(Console.ReadLine(), out int idOfEmplyeeGivenByUser);

                Console.WriteLine("Enter Skill Id of Employee:");
                int.TryParse(Console.ReadLine(), out int givenSkillId);

                if (employeeSkillcontext.Employee.Find(idOfEmplyeeGivenByUser) == null && employeeSkillcontext.Skill.Find(givenSkillId) == null)
                {
                    Console.WriteLine("Either Employee or skill is not present in their parent table.");
                }
                else 
                {
                    var insertEmployeeSkill = new EmployeeSkill()
                    {
                        Id = idOfSkillGivenByUser,
                        EmployeeId = idOfEmplyeeGivenByUser,
                        Skill_ID = givenSkillId,
                    };
                    using (CompanyContext employeeIdContext = new CompanyContext())
                    {
                        employeeSkillcontext.EmployeeSkill.Add(insertEmployeeSkill);
                        employeeSkillcontext.SaveChanges();
                    }
                    Console.WriteLine("Insertion sucessfull");

                }

                Console.WriteLine("Here are elements in EmployeeSkill After insertion:");
                EmployeeSkillRepositery.ShowEmployeeSkillTable();


            }


        }

        public static void ReadEmployeeSkillFormExistingTable()
        {
            CompanyContext employeeSkillcontext = new CompanyContext();
            Console.WriteLine("Enter '1' for read one specific row and '2' all rows:");
            int.TryParse(Console.ReadLine(), out int userChoiceForReadRows);
            switch (userChoiceForReadRows)
            {
                case 1:
                    EmployeeSkill employeeSkill = new EmployeeSkill();
                    Console.WriteLine("Enter the Department_Id of Department table which you want to read row:");
                    int.TryParse(Console.ReadLine(), out int DepartmentIdForReadSpecificRow);
                    employeeSkill = employeeSkillcontext.EmployeeSkill.Find(DepartmentIdForReadSpecificRow);
                    if (DepartmentIdForReadSpecificRow == null)
                    {
                        Console.WriteLine("Row of given Department is not in table!");
                    }
                    else
                    {
                        Console.WriteLine(employeeSkill.Id + " | " + employeeSkill.EmployeeId + " | " + employeeSkill.Skill_ID);

                    }

                    break;
                case 2:
                    EmployeeSkillRepositery.ShowEmployeeSkillTable();
                    break;
                default:
                    Console.WriteLine("Enter valid input.");
                    break;
            }



        }

        /*public static void UpdateEmployeeSkillTable()
        {
            CompanyContext employeeSkillcontext = new CompanyContext();
            Console.WriteLine("Here are rows present in EmloyeeSkill Table:");
            EmployeeSkillRepositery.ShowEmployeeSkillTable();

            Console.WriteLine("Enter the Employee Skill ID  which you want to update:");
            int.TryParse(Console.ReadLine(), out int emplyeeSkillIDForUpdation);

            EmployeeSkill employeeSkill = employeeSkillcontext.EmployeeSkill.Find(emplyeeSkillIDForUpdation);
            if (employeeSkill == null)
            {
                Console.WriteLine("There is not any employeeSkill present with this ID!");
            }
            else
            {
                Console.WriteLine("Enter 1 to update ID of EmployeeSkill.\nEnter 2 to update EmplyeeId of employeeSkill.\nEnter 3 to update skillId of EmployeeSkill.");
                Console.WriteLine("Note,You can't update EmployeeSkill_ID beacuse that is key in table.");
                int.TryParse(Console.ReadLine(), out int userChoiceForUpdateWhichColoumn);

                switch (userChoiceForUpdateWhichColoumn)
                {
                    case 1:
                        Console.WriteLine("Enter new Id of EmployeeSkill:");

                        int.TryParse(Console.ReadLine(), out int employeeSkillIdToBeInserted);
                        if (employeeSkillcontext.Department.Find(employeeSkillIdToBeInserted) != null)
                        {
                            employeeSkill.Id = employeeSkillIdToBeInserted;
                        }
                        else
                        {
                            Console.WriteLine("key can't be updated!");
                        }

                        break;

                    case 2:
                        Console.WriteLine("Enter Id of Employee:");
                        int.TryParse(Console.ReadLine(), out int employeeIdToBeInserted);
                        if (employeeSkillcontext.Department.Find(employeeIdToBeInserted) != null)
                        {
                            employeeSkill.EmployeeId = employeeIdToBeInserted;
                        }
                        else
                        {
                            Console.WriteLine("Forgien key can't be updated!");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Enter new skill Id:");
                        int.TryParse(Console.ReadLine(), out int skillIdToBeInserted);

                        employeeSkill.Skill_ID = skillIdToBeInserted;

                        break;

                }

                employeeSkillcontext.SaveChanges();

            }
            Console.WriteLine("After updation EmployeeSkill table is:");
            EmployeeSkillRepositery.ShowEmployeeSkillTable();
        }*/
        public static void DeteteEmployeeSkillRows()
        {
            CompanyContext employeeSkillcontext = new CompanyContext();
            Console.WriteLine("Here are rows present in EmloyeeSkill Table:");
            EmployeeSkillRepositery.ShowEmployeeSkillTable();

            Console.WriteLine("press 1 to delete a single row from EmployeeSkill,\n 2 to Delete all rows ");

            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the employee skill Id to delete:");
                    int.TryParse(Console.ReadLine(), out int employeeSkillIdToBeDeleted);
                    EmployeeSkill employeeSkillThatWillDeleted = employeeSkillcontext.EmployeeSkill.Find(employeeSkillIdToBeDeleted);
                    if (employeeSkillThatWillDeleted != null)
                    {
                        employeeSkillcontext.EmployeeSkill.Remove(employeeSkillThatWillDeleted);
                        Console.WriteLine("Row deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("There is no record found with id :" + employeeSkillIdToBeDeleted);
                    }
                    employeeSkillcontext.SaveChanges();
                    break;
                case 2:
                    List<EmployeeSkill> employeeSkillList = employeeSkillcontext.EmployeeSkill.ToList<EmployeeSkill>();
                    foreach (EmployeeSkill employeeSkill in employeeSkillList)
                    {
                        employeeSkillcontext.EmployeeSkill.Remove(employeeSkill);
                    }
                    break;
                default:
                    Console.WriteLine("Please enter valid input!");
                    break;
            }

            Console.WriteLine("EmployeeSkill table after deletion:");
            EmployeeSkillRepositery.ShowEmployeeSkillTable();

        }
    }
      
}


