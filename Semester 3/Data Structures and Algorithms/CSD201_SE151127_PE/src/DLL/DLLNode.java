/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package DLL;


/**
 *
 * @author triet
 */
public class DLLNode<E> {
    public E el;
    public DLLNode next, prev;
    
    public DLLNode(){
        el = null;
        next = prev =null;
    }
 
    public DLLNode(E e, DLLNode next, DLLNode prev)
    {
            el = e;
            this.next = next;
            this.prev = prev;
    }
    
    
}

