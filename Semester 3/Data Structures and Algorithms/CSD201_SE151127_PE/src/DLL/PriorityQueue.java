/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DLL;

import DLL.DLLNode;
import DLL.DoublyLinkedList;
import java.util.Comparator;

/**
 *
 * @author triet
 */
public class PriorityQueue<E extends Comparable<? super E>> extends DoublyLinkedList<E>{
    public Comparator<E> comparator;
     //them constructor
    public PriorityQueue(DoublyLinkedList<E> list){ //tao queue tu DLL co san, phai sort lai theo priority
        this.head = list.head;
        this.tail = list.tail;
        this.size = list.size;
        comparator = null;
        this.sortPriority();
        }
    
    public PriorityQueue(DoublyLinkedList<E> list, Comparator comparator){ //tao queue tu DLL co san, phai sort lai theo priority
        this.head = list.head;
        this.tail = list.tail;
        this.size = list.size;
        this.comparator = comparator;
        this.sortPriority();
        }


    public PriorityQueue() { //dung lai constructor ben class DLL
        super();
        comparator = null;
    }
    
        public PriorityQueue(Comparator<E> comparator) { 
        super();
        comparator = comparator;
    }

    public void addByPriority(E el) throws Exception {
         //tim vi tri de add
        int i = 0;
        while (i<size && lessThan(el, (E) get(i).el)){
            i++;   
        }

        AddAt(el, i);
    }

    public void setComparator(Comparator<E> comparator) {
        this.comparator = comparator;
        sortPriority();
    }
    
    
    
    //so sanh 2 elect
    public boolean lessThan(E el1, E el2){
        //Truong hop queue co comparatore
        if(comparator != null) return comparator.compare(el1,el2) < 0; 
        else {
             //Truong hop E implements Comparable:
            if(el1 instanceof Comparable) return ((Comparable) el1).compareTo(el2) < 0;
             //Truong hop E implements Comparator:
                  else return ((Comparator) el1).compare(el1,el2) < 0;
        }
              

                    

    }
    
    public void sortPriority(){ //ham nay de sort queue lai theo priority cua cac Node
        DLLNode current = this.head;
        DLLNode lessPriority = null; //tim node co do uu tien thap hon so voi current de SWAP OBJECT
        
        if(isEmpty()) return;
        else {
            while(current.next!= null){
                lessPriority = current.next;
                while(lessPriority!=null){
                    if(lessThan((E) current.el, (E) lessPriority.el)){
                        //SWAP
                        E tmp = (E) current.el;
                        current.el = lessPriority.el;
                        lessPriority.el = tmp;
                    }
                    lessPriority = lessPriority.next;   
                }
                 current = current.next;
            }
        }
    }
    
    //do node co do uu tien thap nhat ra khoi queue truoc, dequeue dung removeFirst
    //-> priority cang cao cang xa head
    public void enqueue(E el){
        try{
            addByPriority(el); 
        }catch(Exception e){
            System.out.println(e);
            
        }
    }
    
    //phan tu dau tien trong list co priority thap nhat do khi tao queue va add da sap xe theo priority tang dan
    //->tra ve phan tu dau tien cua list va xoa phan tu do khoi list
    public E dequeue(){
        if(isEmpty()) {
            System.out.println("EMPTY QUEUE! There is nothing to dequeue!");
            return null;
        }
            try{
                    E tmp =  front();
                    RemoveFirst();
                    return tmp;
                } catch (Exception e) {
                    System.out.println(e);
                    return null;
        }
           
    }
    
    //tra ve phan tu dau tien cua list
    public E front(){
          if(isEmpty()) {
            System.out.println("EMPTY QUEUE! There is nothing to front!");
            return null;
        }
        try {
            return  (E) get(0).el;
        } catch (Exception e) {
            System.out.println(e);
            return null;
        }
    }
}
