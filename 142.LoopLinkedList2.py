class ListNode:
    def _int_(self, x):
        self.val = x
        self.next = None


"""
我們的目標是：
1.判斷是否有環。
2.如果有環，找出環的入口節點。

核心邏輯
第一步：確認是否有環
slow 每次走一步，fast 每次走兩步。
如果鏈表中有環，快慢指針一定會在環內某個節點相遇。
如果鏈表無環，fast 或 fast.next 會成為 None，退出循環，返回 None。

第二步：確定環的入口
當快慢指針相遇時，說明鏈表有環。
把 slow 指針重新移回鏈表頭部，並且將 fast 指針保持在相遇點。
兩個指針以相同速度（每次移動一步）繼續前進。
當 slow 和 fast 再次相遇時，相遇點就是環的入口。

*為什麼能找到環的入口？
快指針走過的總距離是慢指針的兩倍。
快指針走兩倍慢指針的距離，在走n個環以後遇到慢指針，可以寫成
2(a+b)=a+b+n(b+c) -> a+b=n(b+c) -> a=n(b+c)-b

先拿n為1的情況來舉例，意味著fast指標在環形裡轉了一圈之後，就遇到了 slow指標了。
當n為1的時候，公式就化解為 x = z，
這就意味著，從頭結點出發一個指標，從相遇節點 也出發一個指標，這兩個指標每次只走一個節點， 那麼當這兩個指標相遇的時候就是 環形入口的節點。
也就是在相遇節點處，定義一個指標index1，在頭結點處定一個指標index2。
讓index1和index2同時移動，每次移動一個節點， 那麼他們相遇的地方就是 環形入口的節點。
當我們重新讓 slow 從頭部出發，fast 從相遇點出發，同步前進時，它們會在環的入口相遇，因為兩者距離入口的步數相等。
進入環之前是a,兩指針相遇的前半環是b,兩指針相遇的後半環是c.

那麼 n如果大於1是什麼情況呢，就是fast指針在環形轉n圈之後才遇到 slow指針。
其實這種情況和n為1的時候 效果是一樣的，一樣可以通過這個方法找到 環形的入口節點，只不過，index1 指針在環裡 多轉了(n-1)圈，然後再遇到index2，相遇點依然是環形的入口節點。

"""


class SolutionKKAH2:
    def detectCycle(self, head: ListNode) -> ListNode:
        slow = head
        fast = head
        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next
            if slow == fast:
                slow = head  # a=c 讓他們再相遇就是環的入口了
                while slow != fast:
                    slow = slow.next
                    fast = fast.next
                return slow
        return None
