/*
? 要怎麼在 MyLinkedList 裡面設定 Listnode
* 當我不放上 access modifier，除了 class 預設是 internal，其他預設都是 private，但為了清楚我還是會全部寫出來。
* listnode 屬性都可以為 private，但建立的構造函式必須是 public 才能創建並且被 MyLinkedList 使用


*/

namespace DesignLinkedList;
public class MyLinkedList {
  // 因為 Listnode 僅供 MyLinkedList 使用所以可以為 private
  private class ListNode {
    public int val = 0;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null) {
      this.val = val;
      this.next = next;
    }
  }
  private ListNode dummyhead;
  public MyLinkedList() {
    dummyhead = new ListNode();
  }
  public int Get(int index) {
    if (index < 0) {
      return -1;
    }
    int currentIndex = 0;
    ListNode current = dummyhead;
    while (current.next != null) {
      if (currentIndex == index) {//* dummyhead 不計入 index，所以下一個就是目前的 index
        return current.next.val;
      }
      currentIndex++;
      current = current.next;
    }
    return -1;
  }
  /*
  * 圖解
  * (dummyhead) o-> (next: null or others) o->
  *
  * (dummyhead) o-> (next: null or others) o->
  *     (newhead) o↗
  *
  * (dummyhead) o↓      (next: null or others) o->
  *             (newhead) o↗
  */

  public void AddAtHead(int Val) {
    ListNode newNode = new ListNode(Val, dummyhead.next);
    dummyhead.next = newNode;
  }

  public void AddAtTail(int Val) {
    ListNode current = dummyhead;
    while (current.next != null) {
      current = current.next;
    }
    ListNode newNode = new ListNode(Val, null);
    current.next = newNode;
  }

  public void AddAtIndex(int index, int val) {
    if (index <= 0) {
      AddAtHead(val);
      return;
    }
    int nextIndex = 0; //* dummyhead 不計入 index，所以下一個就是目前的 index，僅作為指向 Head 的指標
    ListNode current = dummyhead;
    ListNode newNode = new ListNode(val);
    while (current.next != null) {
      if (nextIndex == index) {
        ListNode temp = current.next;
        current.next = newNode;
        newNode.next = temp;
        return;
      }
      nextIndex++;
      current = current.next;
    }
    current.next = newNode; //就算 index 等於或超過長度 (012 插入3) 都會添加在尾部
  }

  public void DeleteAtIndex(int index) {
    if (index < 0) {
      return;
    }
    ListNode current = dummyhead;
    int nextIndex = 0;
    while (current.next != null) {
      if (nextIndex == index - 1) {//* 之所以要找前一個節點，是因為要略過他就必須先從前一個指派 next
        current.next = current.next.next;
        return;
      }
      nextIndex++;
      current = current.next;
    }
  }

  //指針法
  public void ReverseListTwoPointers() {
    if (dummyhead.next == null || dummyhead.next.next == null) {
      return;
    }
    ListNode previous = dummyhead.next;
    previous.next = null;
    ListNode current = dummyhead.next.next;
    while (current.next != null) {
      ListNode temp = current.next;
      current.next = previous;
      previous = current;
      current = temp;
    }
    current.next = previous;
    dummyhead.next = current;
  }

  //遞迴法
  //!  ReverseListRecursion 若是使用 public 則會因為 ListNode 為 private 而無法使用，當我們改成 private 的時候 external code 就不能 access 他，所以就可以繼續使用。
  private void ReverseListRecursion(ListNode? pre, ListNode? cur) {
    if (cur == null) {
      dummyhead.next = pre;
      return;
    }
    ListNode? next = cur.next;
    cur.next = pre;
    ReverseListRecursion(cur, next);

  }
  //* ReverseListCallRecursion itself does not expose ListNode to the outside world directly—it does not take a ListNode as a parameter or return a ListNode. Instead, it internally uses the ListNode within the MyLinkedList class, and the external code calling ReverseListCallRecursion never directly interacts with ListNode.
  //* Think ahead: if you make a method public but its parameters are private, how will others know what type of argument to pass? No way jose.
  public void ReverseListCallRecursion() {
    if (dummyhead.next == null || dummyhead.next.next == null) {
      return;
    }
    ListNode cur = dummyhead.next;
    ReverseListRecursion(null, cur);
  }
}
