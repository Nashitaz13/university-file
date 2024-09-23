package jxtreetableexamples;

import java.util.Date;

public class Employee {

	private int id_;
	private String name_;
	private Date date_;
	private String photo_;

	public Employee(int id, String name, Date date, String photo) {
		setId(id);
		setName(name);
		setDate(date);
		setPhoto(photo);
	}

	public int getId() {
		return id_;
	}

	public void setId(int id_) {
		this.id_ = id_;
	}

	public String getName() {
		return name_;
	}

	public void setName(String name_) {
		this.name_ = name_;
	}

	public Date getDate() {
		return date_;
	}

	public void setDate(Date date_) {
		this.date_ = date_;
	}

	public String getPhoto() {
		return photo_;
	}

	public void setPhoto(String photo_) {
		this.photo_ = photo_;
	}
	
}
