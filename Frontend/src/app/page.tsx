'use client'
import axios from "axios";
import Link from "next/link";
import { useRouter } from "next/navigation";

import { ChangeEvent, SyntheticEvent, useState } from "react";


export default function Home() {
  const [Email,SetEmail]=useState("");
  const [Password,SetPassword]=useState("");
  const [Error,SetError]=useState("");

  const router = useRouter();

  const handleEmail=(e:ChangeEvent<HTMLInputElement>)=>{
    SetEmail(e.target.value);
  }
  const handlePassword=(e:ChangeEvent<HTMLInputElement>)=>{
    SetPassword(e.target.value);
  }

  const handleSbmit=async(e:SyntheticEvent)=>{
    e.preventDefault();
    SetError(" ");
  
    if(!Email||!Password){
      SetError("All fields are required.");
      return;
    }else {
     
    try {
      PostData()
      SetError("Login");
    } catch (e : any) {
      SetError(e);
    }
      SetEmail('');
      SetPassword('');
      SetError('');
    }
  };

  async function PostData(){
    
    try{
    const formData=new URLSearchParams();
    formData.append("Email",Email);
    formData.append("Password",Password);
    const res=await axios.post("https://localhost:44315/User/Login",formData,{headers: {'Content-Type': 'application/x-www-form-urlencoded'}});
    const data=res.data
    console.log(data);
    if(data==true){
      router.push("/User/Dashboard");
    }
    }catch(Error){
      console.log(Error);
    }
  }
  
  return(
    <>
    <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="bg-white p-6 rounded shadow-md w-full max-w-sm">
        <h1 className="text-2xl font-bold mb-4">Sign In</h1>
        <form onSubmit={handleSbmit}>
          <div className="mb-4">
            <label htmlFor="Email" className="block text-gray-700">Email</label>
            <input
              type="Email"
              id="Email"
              name="Email"
              className="w-full px-3 py-2 border rounded"
              value={Email}
              onChange={handleEmail}
            />
          </div>
          <div className="mb-4">
            <label htmlFor="Password" className="block text-gray-700">Password</label>
            <input
              type="Password"
              id="Password"
              name="Password"
              value={Password}
              className="w-full px-3 py-2 border rounded"
              onChange={handlePassword}
            />
          </div>
          {Error && <div className="text-red-500 mb-4">{Error}</div>}
            <button type="submit" className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600">Sign In</button>
          <Link href={'User/Registration'} className="text-rose-700">Registration Page</Link>
        </form>
      </div>
    </div>
    </>
  );
}
