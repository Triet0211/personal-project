///*
// * To change this license header, choose License Headers in Project Properties.
// * To change this template file, choose Tools | Templates
// * and open the template in the editor.
// */
//package testQueue;
//
//import DLL.DLLNode;
//import DLL.DoublyLinkedList;
//import DLL.PriorityQueue;
//import java.util.Comparator;
//
///**
// *
// * @author triet
// */
//public class demo1 {
//    public static void main(String[] args) {
//        Comparator<Student> NameComparator = new Comparator<Student>() {
//
//        @Override
//        public int compare(Student s1, Student s2) {
//            return s1.stuName.compareTo(s2.stuName);
//        }};
//        PriorityQueue<Student> queue = new PriorityQueue<>(NameComparator);
//        queue.setComparator(NameComparator);
//        Student stu1 = new Student(3,"Dat");
//        
//        queue.enqueue(stu1);
//        
//        queue.enqueue(new Student(10,"Anh"));
//
//        
//         queue.enqueue(new Student(1,"Triet"));
//        
//    
//         queue.enqueue(new Student(2,"Nhan"));
//         
//         queue.enqueue(new Student(7,"Kiet"));
//         queue.enqueue(new Student(7,"Anh"));
//         queue.enqueue(new Student(5,"Triet"));
//            
//         System.out.println("Khi dung comparator theo name:");
//        queue.printAll();
//        
//        queue.setComparator(null);
//        System.out.println("\nKhi set comparator ve null, dung comparable class Student da implements Comparable:");
//        queue.printAll();
//        
//        System.out.println("\nDDL String:");
//        DoublyLinkedList<String> StringDDL = new DoublyLinkedList<>();
//        StringDDL.AddFirst("abcd");
//        StringDDL.AddFirst("acbd");
//         StringDDL.AddFirst("Bcda123");
//        StringDDL.AddFirst("bcda");
//        StringDDL.AddFirst("Bcda");
//        StringDDL.printAll();
//        PriorityQueue<String> queue2 = new PriorityQueue<>(StringDDL);
//        System.out.println("\nQueue 2 dung constructor tao priority queue tu DDL String");
//        queue2.printAll();
//        
//        System.out.println("\nQueue 3 demo integer: ");
//        PriorityQueue<Integer> queue3 = new PriorityQueue<>();
//        queue3.enqueue(1);
//        queue3.enqueue(5);
//        queue3.enqueue(-8);
//        queue3.enqueue(-5);
//        queue3.printAll();
//          
//        System.out.println("Lay gia tri co do uu tien cao nhat ma ko xoa khoi queue: " + queue3.front() + "     ---size sau khi front: " +queue3.size);
//       
//        System.out.println("Lay gia tri co do uu tien cao nhat ra khoi queue: "+queue3.dequeue() + "   ---size sau khi dequeue: " +queue3.size);
//        queue3.printAll();
//        System.out.println("Lay gia tri co do uu tien cao nhat ra khoi queue: "+queue3.dequeue() + "   ---size sau khi dequeue: " +queue3.size);
//        queue3.printAll();
//        System.out.println("Lay gia tri co do uu tien cao nhat ra khoi queue: "+queue3.dequeue() + "   ---size sau khi dequeue: " +queue3.size);
//        queue3.printAll();
//        System.out.println("Lay gia tri co do uu tien cao nhat ra khoi queue: "+queue3.dequeue() + "   ---size sau khi dequeue: " +queue3.size);
//        queue3.dequeue();
//
//        
//      
//    }
//}
