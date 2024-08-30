using LandPurchase;
using SpiralMatrixII;

using DesignLinkedList;

public class Program {
  public static void Main(string[] args) {
    int test = 707;
    while (true) {
      switch (test) {
        case 707:
          MyLinkedList linkedList = new MyLinkedList();

          // 內建一個簡單的連結串列
          linkedList.AddAtHead(6);
          linkedList.AddAtHead(5);
          linkedList.AddAtHead(4);
          linkedList.AddAtHead(3);
          linkedList.AddAtHead(2);
          linkedList.AddAtHead(1);

          while (true) {
            Console.WriteLine("\n當前連結串列狀態:");
            linkedList.PrintLinkedList(linkedList);

            Console.WriteLine("\n請選擇要執行的操作:");
            Console.WriteLine("1. 在頭部新增節點");
            Console.WriteLine("2. 在尾部新增節點");
            Console.WriteLine("3. 在指定位置新增節點");
            Console.WriteLine("4. 刪除指定位置的節點");
            Console.WriteLine("5. 逆序連結串列（雙指標）");
            Console.WriteLine("6. 逆序連結串列（遞迴）");
            Console.WriteLine("7. 兩兩交換節點");
            Console.WriteLine("8. 刪除倒數第N個節點");
            Console.WriteLine("9. 退出");

            int choice = int.Parse(Console.ReadLine());

            switch (choice) {
              case 1:
                Console.Write("輸入要新增的值: ");
                int addAtHeadVal = int.Parse(Console.ReadLine());
                linkedList.AddAtHead(addAtHeadVal);
                break;
              case 2:
                Console.Write("輸入要新增的值: ");
                int addAtTailVal = int.Parse(Console.ReadLine());
                linkedList.AddAtTail(addAtTailVal);
                break;
              case 3:
                Console.Write("輸入索引位置: ");
                int addAtIndexPos = int.Parse(Console.ReadLine());
                Console.Write("輸入要新增的值: ");
                int addAtIndexVal = int.Parse(Console.ReadLine());
                linkedList.AddAtIndex(addAtIndexPos, addAtIndexVal);
                break;
              case 4:
                Console.Write("輸入要刪除的索引位置: ");
                int deleteAtIndexPos = int.Parse(Console.ReadLine());
                linkedList.DeleteAtIndex(deleteAtIndexPos);
                break;
              case 5:
                linkedList.ReverseListTwoPointers();
                break;
              case 6:
                linkedList.ReverseListCallRecursion();
                break;
              case 7:
                linkedList.SwapPairsMyWay();
                break;
              case 8:
                Console.Write("輸入要刪除的倒數第N個節點的N值: ");
                int deleteAtIndexBackwardsPos = int.Parse(Console.ReadLine());
                linkedList.DeleteAtIndexBackwards(deleteAtIndexBackwardsPos);
                break;
              case 9:
                return; // 退出程式
              default:
                Console.WriteLine("無效的選擇，請重新輸入。");
                break;
            }
          }
        case 3000:
          while (true) {
            LandPurchase.Solution LandPurchaseSolution = new LandPurchase.Solution();
            LandPurchaseSolution.LandPurchase();
            //[Input Example]
            // 3 3
            // 1 2 3
            // 2 1 3
            // 1 2 3
            //[Output Example]
            // 0
          }
        case 59:
          SpiralMatrixII.Solution solution = new SpiralMatrixII.Solution();
          int square = int.Parse(Console.ReadLine());
          solution.PrintMatrix(solution.GenerateMatrix(square));
          int stay = int.Parse(Console.ReadLine());
          break;
      }

    }

  }


}