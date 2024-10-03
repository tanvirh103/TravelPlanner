'use client'
import axios from "axios";
import { ChangeEvent, SyntheticEvent, useState } from "react";

export default function Registration(){
    const [UserName,SetUserName]=useState("");
    const [Email,SetEmail]=useState("");
    const [Password,SetPassword]=useState("");
    const [Error,SetError]=useState("");
    const handleUserName=(e:ChangeEvent<HTMLInputElement>)=>{
      SetUserName(e.target.value);
    }
    const handleEmmail=(e:ChangeEvent<HTMLInputElement>)=>{
      SetEmail(e.target.value);
    }
    const handlePassword=(e:ChangeEvent<HTMLInputElement>)=>{
      SetPassword(e.target.value);
    }
  
    const handleSubmit=async(e:SyntheticEvent)=>{
      e.preventDefault();
      SetError(" ");
  
      if(!UserName||!Email||!Password){
        SetError("All fields are required.");
        return;
      }else {
       
      try {
        postData()
        SetError("user created successfully");
      } catch (e : any) {
        SetError(e);
      }
        SetUserName('');
        SetEmail('');
        SetPassword('');
        SetError('');
      }
    };
  
      async function postData(){
        try{
          const formData=new URLSearchParams();
          formData.append('UserName',UserName);
          formData.append('Email',Email);
          formData.append('Password',Password);
          const res=await axios.post("https://localhost:44315/User/Create",formData,{headers: {'Content-Type': 'application/x-www-form-urlencoded'}});
          const data=res.data;
          console.log(data);
        }catch(Error){
          console.log(Error);
        }
        
      }
    return (
      <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div  className="bg-white p-6 rounded shadow-md w-full max-w-sm"> 
        <h1 className="text-2xl font-bold mb-4">Register</h1>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="username" className="block text-gray-700">Username</label>
            <input
              type="text"
              id="username"
              name="username"
              className="w-full px-3 py-2 border rounded"
              value={UserName}
              onChange={handleUserName}
             
            />
          </div>
          <div className="mb-4">
            <label htmlFor="email" className="block text-gray-700">Email</label>
            <input
              type="email"
              id="email"
              name="email"
              className="w-full px-3 py-2 border rounded"
              value={Email}
              onChange={handleEmmail}
  
            />
          </div>
          <div className="mb-4">
            <label htmlFor="password" className="block text-gray-700">Password</label>
            <input
              type="password"
              id="password"
              name="password"
              className="w-full px-3 py-2 border rounded"
              value={Password}
              onChange={handlePassword}
             
            />
          </div>
          {Error && <div className="text-red-500 mb-4">{Error}</div>}
          <button type="submit" className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600">
            Register
          </button>
        </form>
      </div>
    </div>
    );

}