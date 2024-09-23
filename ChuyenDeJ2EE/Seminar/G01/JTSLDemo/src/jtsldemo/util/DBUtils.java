package jtsldemo.util;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;
 
import jtsldemo.beans.Dept;
import jtsldemo.beans.Emp;
 
public class DBUtils {
 
  private static final List<Dept> DEPARTMENTS = new ArrayList<Dept>();
 
  static {
      initData();
  }
 
  // Mô phỏng dữ liệu trong Database.
  private static void initData() {
 
      Dept accountingDept = new Dept(10, "ACCOUNTING", "NEW YORK");
      accountingDept.addEmployee(new Emp(7782, "CLARK", "MANAGER", "6/9/1981", 2450.00f));
      accountingDept.addEmployee(new Emp(7839, "KING", "PRESIDENT", "11/17/1981", 5000.00f));
      accountingDept.addEmployee(new Emp(7934, "MILLER", "CLERK", "6/9/1981", 1300.00f));
 
      //
      Dept reseachDept = new Dept(20, "RESEARCH", "DALLAS");
      reseachDept.addEmployee(new Emp(7369, "SMITH", "CLERK", "12/17/1980", 800.00f));
      reseachDept.addEmployee(new Emp(7788, "SCOTT", "ANALYST", "4/19/1987", 3000.00f));
      reseachDept.addEmployee(new Emp(7876, "ADAMS", "CLERK", "5/23/1987", 1100.00f));
      reseachDept.addEmployee(new Emp(7876, "FORD", "ANALYST", "12/3/1981", 3000.00f));
      reseachDept.addEmployee(new Emp(7566, "JONES", "MANAGER", "4/2/1981", 2975.00f));
      //
      //
      Dept salesDept = new Dept(30, "SALES", "CHICAGO");
      salesDept.addEmployee(new Emp(7654, "MARTIN", "SALESMAN", "9/28/1981", 1250.00f));
      salesDept.addEmployee(new Emp(7499, "ALLEN", "SALESMAN", "2/20/1981", 1600.00f));
      salesDept.addEmployee(new Emp(7521, "WARD", "SALESMAN", "2/22/1981", 1250.00f));
      salesDept.addEmployee(new Emp(7844, "TURNER", "SALESMAN", "9/8/1981", 1500.00f));
      salesDept.addEmployee(new Emp(7900, "JAMES", "CLERK", "12/3/1981", 950.00f));
      //
      //Dept openrationsDept = new Dept(40, "OPERATIONS", "BOSTON");
      //
 
      DEPARTMENTS.add(accountingDept);
      DEPARTMENTS.add(reseachDept);
      DEPARTMENTS.add(salesDept);
      //DEPARTMENTS.add(openrationsDept);
  }
 
  // Truy vấn các phòng ban.
  public static List<Dept> queryDepartments() {
      return DEPARTMENTS;
  }
 
  // Truy vấn các nhân viên trong 1 phòng ban.
  public static Set<Emp> queryEmployees(int deptNo) {
      for (Dept dept : DEPARTMENTS) {
          if (deptNo == dept.getDeptNo()) {
              return dept.getEmployees();
          }
      }
      return null;
  }
}
