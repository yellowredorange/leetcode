namespace MaxProfitAssignment;

public class Solution {
  public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
    int[] sortIndices = profit
        .Select((value, index) => new { Value = value, Index = index })
        .OrderByDescending(x => x.Value)
        .Select(x => x.Index)
        .ToArray();

    int[] difficultySorted = sortIndices.Select(i => difficulty[i]).ToArray();
    int[] profitSorted = sortIndices.Select(i => profit[i]).ToArray();
    int[] workerSorted = worker.OrderByDescending(x => x).ToArray();
    int sum = 0;
    int limit = 0;
    int upperLimit = difficultySorted.Length;
    int initial = 0;
    for (var i = 0; i < workerSorted.Length; i++) {
      for (var y = initial; y < upperLimit; y++) {
        if (workerSorted[i] < difficultySorted[y]) {
          continue;
        }
        sum += profitSorted[y];
        initial = y;
        y = upperLimit;
      }
    }
    return sum;
  }
}