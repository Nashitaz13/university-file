
public class Authenticator {
	public String authenticate(String username, String password) {
		if (("admin".equalsIgnoreCase(username)) && ("123456".equals(password))) {
			return "success";
		} 
		else {
			return "failure";
		}
	}
}
