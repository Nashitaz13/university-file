package codersontrang.customtag;

import java.io.IOException;

import javax.servlet.jsp.JspTagException;
import javax.servlet.jsp.JspWriter;
import javax.servlet.jsp.tagext.BodyContent;
import javax.servlet.jsp.tagext.BodyTagSupport;

public class Hello extends BodyTagSupport {
	private String name=null;
    private int iterations=1;


	public void setName(String value){
		name = value;
	}

	public String getName(){
		return(name);
	}


	public void setIterations(String value){
     try {
       iterations = Integer.parseInt(value);
     } catch(NumberFormatException nfe) {
       iterations = 1;
     }	
   }

	public String getIterations(){
		return(Integer.toString(iterations));
	}

    public int doStartTag() throws JspTagException{
	  try {
        JspWriter out = pageContext.getOut();
        out.println("<table border=\"1\">");
	     if (name != null)
	      out.println("<tr><td> Hello " + name + " </td></tr>");
        else
	      out.println("<tr><td> Hello World <td></tr>");
	  } catch (Exception ex) {
	    throw new JspTagException("Error." + ex );
	  }
	  // Evaluate the body if there is one
	  return EVAL_BODY_TAG;
    }

	public int doEndTag()throws JspTagException {
	   try {
        	JspWriter out = pageContext.getOut();
	       out.println("</table>");
	   } catch (Exception ex){
	    	throw new JspTagException("Error." + ex);
	   }
	   	finally
	   	{
	   		return SKIP_PAGE;
	   	}
	}

	public int doAfterBody() throws JspTagException {
    if (iterations-- >= 1) {
      BodyContent body = getBodyContent();
      try {
        JspWriter out = body.getEnclosingWriter();
        out.println(body.getString());
        body.clearBody();
      } catch(IOException ioe) {
        throw new JspTagException("Error " + ioe);
      }
      return(EVAL_BODY_TAG);
    } else {
      return(SKIP_BODY); 
	}
}
}