'use client'

import axios from "axios";
import { ChangeEvent, SyntheticEvent, useState } from "react";

export default function CreateTrip(){
    const[Desitination,SetDestination]=useState("");
    const[StartDate,SetStartDate]=useState("");
    const[EndDate,SetEndDate]=useState("");
    const[Itinerary,SetItinerary]=useState("");
    const [Error,SetError]=useState("");
    const [UserId,SetUserId]=useState("");
    const handleDestination=(e:ChangeEvent<HTMLInputElement>)=>{
        SetDestination(e.target.value);
    }
    const handleStartDate=(e:ChangeEvent<HTMLInputElement>)=>{
        SetStartDate(e.target.value);
    }
    const handleEndDate=(e:ChangeEvent<HTMLInputElement>)=>{
        SetEndDate(e.target.value);
    }
    const handleItinerary=(e:ChangeEvent<HTMLInputElement>)=>{
        SetItinerary(e.target.value);
    }
    const handleUserId=(e:ChangeEvent<HTMLInputElement>)=>{
      SetUserId(e.target.value);
  }
    async function PostData(){
        try{
            const formData=new URLSearchParams();
            formData.append("Destination",Desitination);
            formData.append("StartDate",StartDate);
            formData.append("EndDate",EndDate);
            formData.append("Itinerary",Itinerary);
            const res=await axios.post("https://localhost:44315/Trip/Create",formData,{headers: {'Content-Type': 'application/x-www-form-urlencoded'}});
            const data=res.data;
            console.log(data);
        }catch(Error){
            console.log(Error);
        }
       
    }
    const handleSubmit=async(e:SyntheticEvent)=>{
        e.preventDefault();
        SetError(" ");
        if(!Desitination||!StartDate||!EndDate||!Itinerary||!UserId){
            SetError("All fields are required.");
        }else{
            try{
                PostData();
                SetError("Trip Created successfully");
            }catch(Error){
              console.log(Error);
            }
        }
    }
    return(
        <>
        <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div  className="bg-white p-6 rounded shadow-md w-full max-w-sm"> 
        <h1 className="text-2xl font-bold mb-4">Create New Trip</h1>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="Desitination" className="block text-gray-700">Desitination</label>
            <input
              type="text"
              id="Desitination"
              name="Desitination"
              className="w-full px-3 py-2 border rounded"
              value={Desitination}
              onChange={handleDestination}
             
            />
          </div>
          <div className="mb-4">
            <label htmlFor="StartDate" className="block text-gray-700">Start Date</label>
            <input
              type="date"
              id="StartDate"
              name="StartDate"
              className="w-full px-3 py-2 border rounded"
              value={StartDate}
              onChange={handleStartDate}
  
            />
          </div>
          <div className="mb-4">
            <label htmlFor="password" className="block text-gray-700">Password</label>
            <input
              type="date"
              id="EndDate"
              name="password"
              className="w-full px-3 py-2 border rounded"
              value={EndDate}
              onChange={handleEndDate}
             
            />
          </div>
          <div className="mb-4">
            <label htmlFor="Desitination" className="block text-gray-700">Itinerary</label>
            <input
              type="text"
              id="Itinerary"
              name="Itinerary"
              className="w-full px-3 py-2 border rounded"
              value={Itinerary}
              onChange={handleItinerary}
            />
            </div>
            <div className="mb-4">
            <label htmlFor="Desitination" className="block text-gray-700">User Id</label>
            <input
              type="text"
              id="UserId"
              name="UserId"
              className="w-full px-3 py-2 border rounded"
              value={UserId}
              onChange={handleUserId}
            />
            </div>
          {Error && <div className="text-red-500 mb-4">{Error}</div>}
          <button type="submit" className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600">
            Create New Trip
          </button>
        </form>
      </div>
    </div>
    </>
    );
}