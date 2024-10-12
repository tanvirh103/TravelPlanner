import axios from "axios";
interface Packing{
    CheckListId: number;
    ItemName: string;
    IsPacked:boolean;
    TripId:number;
}
process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

export default async function GetAllBudget(){
    const res=await axios.get(process.env.Net_Api+"/Packing/GetAll");
    const Packings:Packing[]=await res.data;
    return(
        <>
         <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-4xl">
        <h1 className="text-2xl font-bold mb-6 text-center">List Of Packing</h1>
        <table className="min-w-full border-collapse border border-slate-400">
          <thead>
            <tr className="bg-gray-200">
              <th className="border border-slate-300 px-4 py-2 text-left">Packing ID</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Item Name</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Is Packed</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Trip Id</th>
            </tr>
          </thead>
          <tbody>
            {Packings.map((Packing) => (
              <tr key={Packing.CheckListId} className="even:bg-gray-50 odd:bg-white">
                <td className="border border-slate-300 px-4 py-2">{Packing.CheckListId}</td>
                <td className="border border-slate-300 px-4 py-2">{Packing.ItemName}</td>
                <td className="border border-slate-300 px-4 py-2">{Packing.IsPacked ? "✅" : "❌"}</td>
                <td className="border border-slate-300 px-4 py-2">{Packing.TripId}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
    </>
    );
}