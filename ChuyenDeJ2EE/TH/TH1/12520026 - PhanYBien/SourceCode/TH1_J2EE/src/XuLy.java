import java.io.IOException;
import java.io.PrintWriter;
import java.lang.Thread;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class XuLy extends HttpServlet {

	protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		response.setContentType("text/html;charset=UTF-8");
		PrintWriter out = response.getWriter();
		try {
			HttpSession session = request.getSession(true);
			GioHang gh=(GioHang)(session.getAttribute("giohang"));
			if(gh==null)
			gh=new GioHang();
			String hang=request.getParameter("cbohang");
			MonHang mh=new MonHang(hang,0d,"");
			gh.ThemMonhang(mh);
			session.setAttribute("giohang", gh);
			RequestDispatcher rd=request.getRequestDispatcher("MuaHang");
			rd.forward(request, response);
		} 
		finally {
			out.close();
		}
	}
	
	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		processRequest(request, response);
	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		processRequest(request, response);
	}
}