using System;
using System.Collections.Generic;
using System.Text;

namespace IntroCompetitiveProgrammingCodes.Day_25
{
    class EmployeeImportance
    {
		public int getImportance(List<Employee> employees, int id) {
			HashMap<Integer, Employee> employeeMap = new HashMap<>();
			Employee theGuy = new Employee();
			for (Employee emp : employees)
			{
				if(emp.id == id)
				{
					theGuy = emp;
				}
            
				employeeMap.put(emp.id, emp);
			}
        
			return Importance(employeeMap, theGuy);
		}
    
		public int Importance(Map<Integer, Employee> employeeMap, Employee employee) {
			if(employee == null)
				return 0;
        
			int importance = employee.importance;
        
			for (int subordinate : employee.subordinates)
				importance += Importance(employeeMap, employeeMap.get(subordinate));
        
			return importance;
		}
    }
}
