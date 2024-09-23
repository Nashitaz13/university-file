package jtsl.servlet.core;

import java.io.IOException;
import java.util.List;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import jtsldemo.beans.Dept;
import jtsldemo.util.DBUtils;

/**
 * Servlet implementation class forEach
 */
@WebServlet("/core/forEach")
public class forEach extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public forEach() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		List<Dept> list = DBUtils.queryDepartments();
        
        
	       // Ghi dữ liệu vào thuộc tính 'departments' của request.
	       request.setAttribute("departments", list);
	 
	       // Tạo RequestDispatcher để chuyển tiếp yêu cầu tới jstl_core_example01.jsp
	       RequestDispatcher dispatcher = getServletContext()
	               .getRequestDispatcher("/WEB-INF/views/core/core_forEach_view.jsp");
	        
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
