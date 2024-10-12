'use client'
import axios from "axios";
import { ChangeEvent, SyntheticEvent, useState } from "react";

export default function CreateBudget(){
    const[BudgetItem,SetBudgetItem]=useState("");
    const[EstimatedCost,SetEstimatedCost]=useState("");
    const[TripId,SetTripId]=useState("");  
    const [Error,SetError]=useState("");
    const handleBudgetItem=(e:ChangeEvent<HTMLInputElement>)=>{
        SetBudgetItem(e.target.value);
    }
    const handleEstimatedCost=(e:ChangeEvent<HTMLInputElement>)=>{
        SetEstimatedCost(e.target.value);
    }
    const handleTripId=(e:ChangeEvent<HTMLInputElement>)=>{
        SetTripId(e.target.value);
    }
    async function PostData(){
        try{
            const formData=new FormData();
            formData.append("BudgetItem",BudgetItem);
            formData.append("EstimatedCost",EstimatedCost);
            formData.append("TripId",TripId);
            const res=await axios.post("https://localhost:44315/Budget/Create",formData,{headers: {'Content-Type': 'application/json'}});
            const data=res.data;
            console.log(data);
        }catch(Error){
            console.log(Error);
        }
       
    }
    const handleSubmit=async(e:SyntheticEvent)=>{
        e.preventDefault();
        SetError(" ");
        if(!BudgetItem||!EstimatedCost||!TripId){
            SetError("All fields are required.");
        }else{
            try{
                PostData();
                SetError("Budget Created successfully");
            }catch(Error){
              console.log(Error);
            }
        }
    }
    return(
        <>
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div  className="bg-white p-6 rounded shadow-md w-full max-w-sm"> 
        <h1 className="text-2xl font-bold mb-4">Create New Budget</h1>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="Desitination" className="block text-gray-700">Budget Item</label>
            <input
              type="text"
              id="BudgetItem"
              name="BudgetItem"
              className="w-full px-3 py-2 border rounded"
              value={BudgetItem}
              onChange={handleBudgetItem}
             
            />
          </div>
          <div className="mb-4">
            <label htmlFor="StartDate" className="block text-gray-700">Estimated Cost</label>
            <input
              type="number"
              id="EstimatedCost"
              name="EstimatedCost"
              className="w-full px-3 py-2 border rounded"
              value={EstimatedCost}
              onChange={handleEstimatedCost}
  
            />
          </div>
          <div className="mb-4">
            <label htmlFor="password" className="block text-gray-700">Trip Id</label>
            <input
              type="number"
              id="TripId"
              name="TripId"
              className="w-full px-3 py-2 border rounded"
              value={TripId}
              onChange={handleTripId}
             
            />
          </div>
          {Error && <div className="text-red-500 mb-4">{Error}</div>}
          <button type="submit" className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600">
            Create New Budget
          </button>
        </form>
      </div>
    </div>
    </>
    );
}