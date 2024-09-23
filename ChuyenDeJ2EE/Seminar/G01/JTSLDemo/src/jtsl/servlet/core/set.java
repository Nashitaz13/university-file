package jtsl.servlet.core;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import jtsldemo.beans.Emp;

/**
 * Servlet implementation class set
 */
@WebServlet("/core/set")
public class set extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public set() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		boolean first = Boolean.parseBoolean(request.getParameter("isfirst"));
		if(first){
			request.setAttribute("first", "Hello every body");
		}
		Emp item = new Emp(7369, "SMITH", "CLERK", "12/17/1980", 800.00f);
        
	       // Ghi dữ liệu vào thuộc tính 'departments' của request.
	       request.setAttribute("Employee", item);
	       // Tạo RequestDispatcher để chuyển tiếp yêu cầu tới jstl_core_example01.jsp
	       RequestDispatcher dispatcher = getServletContext()
	               .getRequestDispatcher("/WEB-INF/views/core/core_set_view.jsp");
	        
	       // Chuyển tiếp yêu cầu, để hiển thị trên trang JSP.
	       dispatcher.forward(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
