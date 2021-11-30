/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package PriorityQueue;

import java.util.Comparator;

/**
 *
 * @author triet
 */
public class DoublyLinkedList<E> {
    public DLLNode<E> head, tail;
    public int size;
     
    public DoublyLinkedList()
    {
            head = tail =  null;
            size = 0;
            
    }

    public DoublyLinkedList(DLLNode head, DLLNode tail, int size) {
        this.head = head;
        this.tail = tail;
        this.size = size;

    }
    
    //kiem tra xem list co rong hay khong
    public boolean isEmpty()
    {
            return size == 0;
    }
    
    //xoa tat ca phan tu trong list
    public void clear()
    {
            head = tail = null;
            size = 0;
    }
    
    //them phan tu o dau list
       public void AddFirst(E el)
    {
            DLLNode newest = new DLLNode(el,null,null);
            newest.next = head;
            if(head != null){
                head.prev=newest;
            }
            head = newest;
            size++;
            if(tail == null)
                    tail = head;
    }
    
       //them phan tu vao cuoi list
    public void AddLast(E el)
    {
            DLLNode newest = new DLLNode(el,null,null);
            if (isEmpty()) head = tail = newest;
            else {
                    newest.prev = tail;
                    tail.next = newest;
                    tail = newest;
            }
            size++;	
    }
    
    //tra ve node tai vi tri cu the (head co index la 0)
    public DLLNode get(int position)  throws IndexOutOfBoundsException
    {
            if(isEmpty() || position >= size)
                throw new IndexOutOfBoundsException();
            else
            {
                DLLNode temp = head;
                int tmp = 0;
                    while(tmp!=position)
                    {
                           temp = temp.next;
                           tmp++;
                    }
                return temp;
            }
         
    }
    

    //them tai vi tri bat ki, cac phan tu luc dau o vi tri nay tro di bi dich ve sau
    public void AddAt(E el, int pos) throws Exception {
    if(pos<0 || pos>size) throw new IndexOutOfBoundsException();
    else if(pos == 0)  AddFirst(el); //neu add vao vi tri 0 thi dung addFirst
                else if(pos == size) AddLast(el); //neu add vao vi tri cuoi list thi dung addLast
                else{
                    //khoi tao node duoc them vao
                    DLLNode newest = new DLLNode(el, null, null);
                    
                    DLLNode current = head;
                    
                    //tim den vi tri can them
                    for(int i = 0; i<=pos-1; i++)
                        current = current.next;  
                    
                     //khoi tao cac moi lien ket moi
                     newest.next = current;
                     newest.prev = current.prev;
                     current.prev.next = newest;
                     current.prev = newest;
                    
                    size++;
                }
    }
    

    
    
    public void RemoveFirst() {
        if(isEmpty()) return;
        else{
            if(head==tail) {
                head = tail =null;
                size--;
            }
            else{
            head = head.next;
            head.prev = null;
            size--;
             }
    }}
    
    public void RemoveLast() throws Exception {
        if(isEmpty()) throw new Exception("Empty List!");
        else{
            tail = tail.prev;
            tail.next = null;
            size--;
        }
    }
    

    public void printAll(){
        if(isEmpty()) System.out.println("EMPTY LIST!!!");
        DLLNode tmp = head;
        while(tmp != null){
            System.out.println(tmp.el.toString());
            tmp=tmp.next;
        }
    }
    
    

}