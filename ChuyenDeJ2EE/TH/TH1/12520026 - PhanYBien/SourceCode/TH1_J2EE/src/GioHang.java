import java.util.ArrayList;
public class GioHang {
	private ArrayList<MonHang>giohang;

	public GioHang(){
		giohang=new ArrayList<MonHang>();
	}
	
	public void ThemMonhang(MonHang mh){
		if(giohang.contains(mh)){
			MonHang mhang=giohang.get(giohang.indexOf(mh));
		}
		else {
			giohang.add(mh);
		}
	}

	public MonHang LayMonHang(int i){
		if(i<0||i>giohang.size()-1)
		return null;
		return giohang.get(i);
	}

	public ArrayList<MonHang> getGiohang(){
		return giohang;
	}

	public boolean XoaMonHang(String ten){
		MonHang mh=new MonHang(ten,0d,"");
		if(!giohang.contains(mh))
			return false;
		else
			return true;
	}

	public int soMonHang(){
	return giohang.size();
	}
}
