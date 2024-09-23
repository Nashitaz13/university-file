package jtsldemo.beans;

import java.util.HashSet;
import java.util.Set;
 
public class Dept {
 
  private int deptNo;
  private String deptName;
  private String location;
 
  private Set<Emp> employees;
 
  public Dept() {
 
  }
 
  public Dept(int deptNo, String deptName, String location) {
      this.deptNo = deptNo;
      this.deptName = deptName;
      this.location = location;
  }
 
  public int getDeptNo() {
      return deptNo;
  }
 
  public void setDeptNo(int deptNo) {
      this.deptNo = deptNo;
  }
 
  public String getDeptName() {
      return deptName;
  }
 
  public void setDeptName(String deptName) {
      this.deptName = deptName;
  }
 
  public String getLocation() {
      return location;
  }
 
  public void setLocation(String location) {
      this.location = location;
  }
 
  public Set<Emp> getEmployees() {
      return employees;
  }
 
  public void setEmployees(Set<Emp> employees) {
      this.employees = employees;
  }
  
  public void addEmployee(Emp employee)  {
      if(this.employees== null)  {
          this.employees= new HashSet<Emp>();
      }
      this.employees.add(employee);
  }
}