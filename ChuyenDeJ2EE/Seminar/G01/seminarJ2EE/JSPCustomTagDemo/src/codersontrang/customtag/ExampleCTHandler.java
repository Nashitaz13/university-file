package codersontrang.customtag;

import java.io.IOException;  
import javax.servlet.jsp.JspException;  
import javax.servlet.jsp.JspWriter;  
import javax.servlet.jsp.tagext.TagSupport;  

public class ExampleCTHandler extends TagSupport{  
     private String content;  
     private String color;  

     @Override  
     public int doStartTag() throws JspException {  
          try{  
               JspWriter out = pageContext.getOut();  

               StringBuffer tagGen = new StringBuffer();  
               tagGen.append("<span style=\"color:");  
               tagGen.append(color);  
               tagGen.append("\">");  
               tagGen.append(content);  
               tagGen.append("</span>");  

               out.print(tagGen.toString());  
          }catch(Exception e){  
               e.printStackTrace();  
          }  
          return SKIP_BODY;  
     }  

     public String getContent() {  
          return content;  
     }  
     public void setContent(String content) {  
          this.content = content;  
     }  
     public String getColor() {  
          return color;  
     }  
     public void setColor(String color) {  
          this.color = color;  
     }  
}  
