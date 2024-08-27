/* 
* ListNode is a public Reference Type. When I assgin a reference type to another variable, both variables share same object. That's why I can use 'current.next=' to change those original ListNodes.
? What's the difference between ShallowCopy and DeepCopy?
* ShallowCopy 對於 Value Types 都能直接 assgin the value，ex: int, string, bool, Structs，詳細的 Value Type 筆記放在最下面。但對於 Reference Type 只會讓他們指向同一個物件，所以更改會連動。
* DeepCopy 就是對於 Reference Type Assignment 而做。
* Array 範例
Person[] deepCopyArray = new Person[originalArray.Length];
for (int i = 0; i < originalArray.Length; i++)
{
    deepCopyArray[i] = new Person(originalArray[i].Name); // 創建每個 Person 的副本
}

* List 範例
List<Person> deepCopyList = new List<Person>();
foreach (var person in originalList)
{
    deepCopyList.Add(new Person(person.Name)); // 創建每個 Person 的副本
}
* ListNode 範例
在 ListNode Class 新建一個方法
public ListNode DeepCopy(){
  ListNode newNode = new ListNode(this.Value);
  if(this.Next != null){
!    newNode.Next = this.Next.DeepCopy();
* 每位的下一位使用遞迴呼叫 DeepCopy，就會讓接下來全部都是 DeepCopy
  }
  return newNode;
}
 */
public class ListNode { //*三個要素: value, next node, 建構函式
  public int val;
  public ListNode next;
  public ListNode(int val = 0, ListNode next = null) {
    this.val = val;
    this.next = next;
  }
}

public class Solution {
  public ListNode RemoveElements(ListNode head, int val) {
    if (head != null && head.val == val) {// 先檢查 head 本身是不是 null，才不會.val 的時候拋出 NullReferenceException
      head = head.next;
    }
    ListNode current = head;
    while (current != null && current.next != null) {// 第一個不等於 null 是為了 head 如果一開始就被移除了，那 null 本身並不具備.next屬性，所以避免 NullReferenceException
      if (current.next.val == val) { //*這段的邏輯就是，目前current已經是一定會保留的內容，剩下的只要去變動 next 應該是誰，就可以自動跳過，而不需要先讓 current=next，再去判別 current。
        current.next = current.next.next;
      } else {
        current = current.next;
      }
    }
    return head;
  }
}

public class DummyHeadSolution {
  public ListNode RemoveElements(ListNode head, int val) {
    ListNode DummyHead = new ListNode(0, head); //先設立一個 DummyHead 去指向 head，就不需要額外去判斷 head
    ListNode current = DummyHead;
    while (current != null && current.next != null) {
      if (current.next.val == val) {
        current.next = current.next.next;
      } else {
        current = current.next;
      }
    }
    return DummyHead.next;//*簡單明瞭的捨棄 DummyHead
  }
}

/*
! Value Types
? Built-in Numeric Types
* Integral Types: byte, sbyte, short, ushort, int, uint, long, ulong.
* Floating-potin Types: float, double, decimal
* 16 unicode: char
? Boolean Type
* bool
? Struts
* DateTime, TimeSpan or You can define it by all value types.
public struct body
{
    public float height;
    public float weight;
    public float Body Fat;
}
? Enums
* It is a special type for a set of variables of a relationship.
public enum DaysOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}
* They have implicit integers.
DaysOfWeek today = DaysOfWeek.Monday;
Console.WriteLine(today); // 輸出: Monday
Console.WriteLine((int)today); // 輸出: 1
? Tuple
* If they are all Value Types.
(int, int) tuple = (1, 2);

! Referenc Types
* Class
* Arrays
* Interface
Delegates
Anonymous Methods and Lambda Expressions
Events
Dynamic Type (dynamic)
Object Type (object)
StringBuilder
Nullable<T> (when T is a reference type)
Tuple (when elements are reference types)
Task and Task<T>
Exception and Derived Types

*/