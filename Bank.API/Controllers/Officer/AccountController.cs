using System;
using System.Threading.Tasks;
using AutoMapper;
using Bank.API.Controllers.Teller;
using Bank.API.Models;
using Bank.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers.Officer
{
  [ApiController]
  [Route("api/officer/[controller]")]
  public class AccountController: ControllerBase
  {
    private readonly IOfficerRepository _repository;
    private readonly IMapper _mapper;

    public AccountController(IOfficerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<AccountModel>> Post(AccountModel model)
    {
      try
      {
        if (model?.CustomerId < 1) return BadRequest();
        var account = _mapper.Map<Account>(model);
        _repository.Add(account);
        if (await _repository.SaveChangesAsync())
        {
          return Created("", _mapper.Map<AccountModel>(account));
        }
      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }

      return BadRequest();
    }
    
    [HttpGet]
    public async Task<ActionResult<AccountModel[]>> Get()
    {
      try
      {
        var results = await _repository.GetAllAccountsAsync();
        // return _mapper.Map<AccountModel[]>(results);
        var mapped = _mapper.Map<AccountModel[]>(results);
        return mapped;

      }
      catch (Exception e)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, e);
      }
    }

  }
  class MergeSort
        {
            public static int[] mergeSort(int[] array)
            {
                int[] left;
                int[] right;
                int[] result = new int[array.Length];  
                //As this is a recursive algorithm, we need to have a base case to 
                //avoid an infinite recursion and therfore a stackoverflow
                if (array.Length <= 1)
                    return array;              
                // The exact midpoint of our array  
                int midPoint = array.Length / 2;  
                //Will represent our 'left' array
                left = new int[midPoint];
      
                //if array has an even number of elements, the left and right array will have the same number of 
                //elements
                if (array.Length % 2 == 0)
                    right = new int[midPoint];  
                //if array has an odd number of elements, the right array will have one more element than left
                else
                    right = new int[midPoint + 1];  
                //populate left array
                for (int i = 0; i < midPoint; i++)
                    left[i] = array[i];  
                //populate right array   
                int x = 0;
                //We start our index from the midpoint, as we have already populated the left array from 0 to
                for (int i = midPoint; i < array.Length; i++)
                {
                    right[x] = array[i];
                    x++;
                }  
                //Recursively sort the left array
                left = mergeSort(left);
                //Recursively sort the right array
                right = mergeSort(right);
                //Merge our two sorted arrays
                result = merge(left, right);  
                return result;
            }
      
            //This method will be responsible for combining our two sorted arrays into one giant array
            public static int[] merge(int[] left, int[] right)
            {
                int resultLength = right.Length + left.Length;
                int[] result = new int[resultLength];
                //
                int indexLeft = 0, indexRight = 0, indexResult = 0;  
                //while either array still has an element
                while (indexLeft < left.Length || indexRight < right.Length)
                {
                    //if both arrays have elements  
                    if (indexLeft < left.Length && indexRight < right.Length)  
                    {  
                        //If item on left array is less than item on right array, add that item to the result array 
                        if (left[indexLeft] <= right[indexRight])
                        {
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        // else the item in the right array wll be added to the results array
                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }
                    //if only the left array still has elements, add all its items to the results array
                    else if (indexLeft < left.Length)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    //if only the right array still has elements, add all its items to the results array
                    else if (indexRight < right.Length)
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }  
                }
                return result;
            }
        }

}