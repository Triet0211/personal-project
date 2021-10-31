/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testQueue;


/**
 *
 * @author triet
 */
public class Student implements Comparable<Student>{
    public int stuID;
    public String stuName;
    
    public Student(){
    }

    public Student(int stuID, String stuName) {
        this.stuID = stuID;
        this.stuName = stuName;
    }

    public int getStuID() {
        return stuID;
    }

    public void setStuID(int stuID) {
        this.stuID = stuID;
    }

    public String getStuName() {
        return stuName;
    }

    public void setStuString(String stuName) {
        this.stuName = stuName;
    }
    
    @Override
    public int compareTo(Student t) {
        if(stuID > t.stuID) return 1;
        else if(stuID < t.stuID) return -1;
        else return 0;
    }

    @Override
    public String toString() {
        return "Student{" + "stuID=" + stuID + ", stuName=" + stuName + '}';
    }
//
//    @Override
//    public int compare(Student t, Student t1) {
//        return t.stuID - t1.stuID;
//    }


    

 }

