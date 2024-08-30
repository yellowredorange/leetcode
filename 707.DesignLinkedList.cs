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
  // 列印連結串列的內容
  public void PrintLinkedList(MyLinkedList linkedList) {
    var current = linkedList.GetHead();
    while (current != null) {
      Console.Write(current.val + " -> ");
      current = current.next;
    }
    Console.WriteLine("null");
  }
  private ListNode? GetHead() {
    return dummyhead.next;
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
    // ListNode previous = dummyhead.next; //
    // previous.next = null; //這樣會切斷dummyhead.next，後面都找不到dummyhead剩下的一串，但又需要讓previous接著null才有最後終點，所以應該要直接讓previous一開始為null，極為類似dummyhead的終點。
    // ListNode current = dummyhead.next.next;
    ListNode previous=null;
    ListNode current=dummyhead.next;
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

  public void SwapPairsMyWay() {
    if (dummyhead.next == null || dummyhead.next.next == null) {
      return;
    }
    ListNode cur = dummyhead; //底下會因為cur.next變成secondNode，所以不需要特別處理頭部的問題
    while (cur.next != null && cur.next.next != null) {
      ListNode firstNode = cur.next;
      ListNode secondNode = cur.next.next;
      cur.next = secondNode; //cur最左的人先斷練
      firstNode.next = secondNode.next; //先動最右邊的人
      secondNode.next = firstNode; //再斷鏈
      cur = firstNode; //cur.next和cur.next.next就會是下一對


    }
  }
  // 虚拟头结点
  public void SwapPairsOtherWay() {
    var dummyHead = new ListNode();

    ListNode cur = dummyHead;
    while (cur.next != null && cur.next.next != null) {
      ListNode tmp1 = cur.next;
      ListNode tmp2 = cur.next.next.next;

      cur.next = cur.next.next;
      cur.next.next = tmp1;
      cur.next.next.next = tmp2;

      cur = cur.next.next;
      /*
      Step 1:

      tmp1 = 1
      tmp2 = 3
      cur -> 1 -> 2 -> 3 -> 4 -> ...

      Step 2: 交換節點
      cur.next = cur.next.next;  // cur.next 指向 2
      操作後，節點的引用關係如下：

      cur -> 2 -> 3 -> 4 -> ...
      tmp1 = 1
      tmp2 = 3
      在這一步，cur 已經指向了節點 2，但是節點 1 還沒有被重新連線。此時節點 1 被“斷鏈”了，因為它不再被任何節點指向。

      Step 3: 調整指向

      cur.next.next = tmp1; // 將 2 的 next 指向 1
      操作後，節點的引用關係如下：

      cur -> 2 -> 1    3 -> 4 -> ...
      tmp2 = 3
      現在，1 被連線回連結串列，變成了 2 的後繼節點。

      Step 4: 連線下一個待處理節點

      cur.next.next.next = tmp2; // 將 1 的 next 指向 3
      操作後，節點的引用關係如下：

      cur -> 2 -> 1 -> 3 -> 4 -> ...
      */
    }
  }
  public void DeleteAtIndexBackwards(int index) {
    ListNode fastNode = dummyhead;
    ListNode slowNode = dummyhead;
    for (int i = 0; i < index; i++) { //原本這裡用了index跟while去判斷index到了沒，但其實簡化成for以後，在裡面再塞一個fastnode.next==null直接讓他return會更簡約簡化。
      if (fastNode.next == null) {
        return;
      }
      fastNode = fastNode.next;
    }
    while (fastNode.next != null) {
      fastNode = fastNode.next;
      slowNode = slowNode.next;
    }
    slowNode.next = slowNode.next.next;
  }
}
