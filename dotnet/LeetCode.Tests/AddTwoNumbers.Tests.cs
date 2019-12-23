using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class AddTwoNumbers
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) => val = x;
            public override string ToString() => val + (next != null ? "->" + next : String.Empty);
        }
        
        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                List<string> listL1 = FlattenListToStrings(l1, new List<string>());
                List<string> listL2 = FlattenListToStrings(l2, new List<string>());

                listL1.Reverse();
                listL2.Reverse();

                var number1 = DigitsToNumber(listL1);
                var number2 = DigitsToNumber(listL2);

                var resultAsNumber = number1 + number2;

                List<char> resultAsDigits = resultAsNumber.ToString().Reverse().ToList();

                var resultingListNode = new ListNode(int.Parse(resultAsDigits[0].ToString()));
                resultingListNode.next = new ListNode(int.Parse(resultAsDigits[1].ToString()));
                resultingListNode.next.next = new ListNode(int.Parse(resultAsDigits[2].ToString()));
                
                return resultingListNode;
            }

            private int DigitsToNumber(List<string> listL)
            {
                StringBuilder concatenatedString = new StringBuilder();
                foreach (var item in listL) concatenatedString.Append(item);
                return int.Parse(concatenatedString.ToString());
            }

            private List<string> FlattenListToStrings(ListNode linkedList, List<string> list)
            {
                list.Add(linkedList.val.ToString());
                if (linkedList.next != null) FlattenListToStrings(linkedList.next, list);
                return list;
            }
        }

        /// <list type="bullet">  
        /// <item><description>Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)</description></item>  
        /// <item><description>Output: 7 -> 0 -> 8</description></item>  
        /// <item><description>Explanation: 342 + 465 = 807</description></item>  
        /// </list>  
        [Fact]
        public void SimpleArraySumTest()
        {
            var linkedListOne = new ListNode(2);
            linkedListOne.next = new ListNode(4);
            linkedListOne.next.next = new ListNode(3);

            var linkedListTwo = new ListNode(5);
            linkedListTwo.next = new ListNode(6);
            linkedListTwo.next.next = new ListNode(4);
            
            var outputLinkedList = new ListNode(7);
            outputLinkedList.next = new ListNode(0);
            outputLinkedList.next.next = new ListNode(8);

            var solution = new Solution();
            var result = solution.AddTwoNumbers(linkedListOne, linkedListTwo);
            
            Assert.Equal(outputLinkedList.ToString(), result.ToString());
        }
    }
}