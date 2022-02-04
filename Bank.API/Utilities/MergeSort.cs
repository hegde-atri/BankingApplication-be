using Bank.API.Models;

namespace Bank.API.Utilities
{
    public class MergeSort
        {
            public static AccountModel[] MergeSortAccountModels(AccountModel[] array)
            {
                AccountModel[] left;
                AccountModel[] right;
                AccountModel[] result = new AccountModel[array.Length];  
                
                // our base case to stop the recursion
                if (array.Length <= 1)
                    return array;
                int midPoint = array.Length / 2;  
                // left array
                left = new AccountModel[midPoint];
      

                // we are setting the length of the right array, if there are an even number of elements
                // the left and right arrays will be symmetrical in terms of length (same length)
                
                if (array.Length % 2 == 0)
                    right = new AccountModel[midPoint];  
                // when the length is odd, that means that the right must be 1 longer.
                else
                    right = new AccountModel[midPoint + 1];  
                // populate left array
                for (int i = 0; i < midPoint; i++)
                    left[i] = array[i];  
                // populate right array   
                int x = 0;
                for (int i = midPoint; i < array.Length; i++)
                {
                    right[x] = array[i];
                    x++;
                }  
                
                //Recursively sort the left array
                left = MergeSortAccountModels(left);
                //Recursively sort the right array
                right = MergeSortAccountModels(right);
                //Merge our two sorted arrays
                result = mergeAccountModels(left, right);  
                return result;
            }
      
            // This method will be merging 2 given arrays.
            public static AccountModel[] mergeAccountModels(AccountModel[] left, AccountModel[] right)
            {
                int resultLength = right.Length + left.Length;
                AccountModel[] result = new AccountModel[resultLength];
                // initialising our indexes/pointers.
                int indexLeft = 0, indexRight = 0, indexResult = 0;  
                // while there is is unadded(to the result) account object in one of the arrays (right or left)
                while (indexLeft < left.Length || indexRight < right.Length)
                {
                    // If there are still unadded (to the result) account objects on both arrays (left and right)
                    if (indexLeft < left.Length && indexRight < right.Length)  
                    {  
                        // here we add the account with the lesser balance to the result
                        if (left[indexLeft].Balance <= right[indexRight].Balance)
                        {
                            result[indexResult] = left[indexLeft];
                            // we move up the left array index by one
                            indexLeft++;
                            // increment the result array index as we have added an account to it
                            indexResult++;
                        }
                        else
                        {
                            result[indexResult] = right[indexRight];
                            // we move up the right array index by one
                            indexRight++;
                            // increment the result array index as we have added an account to it
                            indexResult++;
                        }
                    }
                    // if there is an account on the left array
                    else if (indexLeft < left.Length)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // if there is an account on the right array
                    else if (indexRight < right.Length)
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }  
                }
                // Since we have passed through all the accounts, the array is sorted
                // so we return it.
                return result;
            }
        }
    
}