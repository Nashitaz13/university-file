public class MonHang {
	
	private String ten;
	private double gia;
	private String ghichu;
	
	@Override
	public String toString() {
		return ten+";"+ gia +";"+ ghichu;
	}
	
	public String getTen() {
		return ten;
	}
	
	public void setTen(String ten) {
		this.ten = ten;
	}
	
	public double getGia() {
		return gia;
	}
	
	public void setGia(double gia) {
		this.gia = gia;
	}
	
	public String getGhiChu() {
		return ghichu;
	}
	
	public void setGhiChu(String ghichu) {
		this.ghichu = ghichu;
	}
	
	public MonHang(String ten, double gia, String ghichu) {
		super();
		this.ten = ten;
		this.gia = gia;
		this.ghichu = ghichu;
	}
	
	public MonHang() {
		super();
	}
	
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((ten == null) ? 0 : ten.hashCode());
		return result;
	}
	
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		MonHang other = (MonHang) obj;
		if (ten == null) {
		if (other.ten != null)
			return false;
		} else if (!ten.equals(other.ten))
		return false;
		return true;
	}
}