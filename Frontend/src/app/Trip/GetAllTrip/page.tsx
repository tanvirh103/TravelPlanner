import axios from "axios";
interface Trip{
    TripId: number;
    Destination: string;
    StartDate:string;
    EndDate:string
    Itinerary:string
    
}
process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

export default async function GetAllTrip(){
    const res=await axios.get(process.env.Net_Api+"/Trip/GetAll");
    const Trips:Trip[]=await res.data;
    return(
        <>
         <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-4xl">
        <h1 className="text-2xl font-bold mb-6 text-center">List Of Trips</h1>
        <table className="min-w-full border-collapse border border-slate-400">
          <thead>
            <tr className="bg-gray-200">
              <th className="border border-slate-300 px-4 py-2 text-left">Trip ID</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Destination</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Start Date</th>
              <th className="border border-slate-300 px-4 py-2 text-left">End Date</th>
              <th className="border border-slate-300 px-4 py-2 text-left">Itinerary</th>
            </tr>
          </thead>
          <tbody>
            {Trips.map((Trip) => (
              <tr key={Trip.TripId} className="even:bg-gray-50 odd:bg-white">
                <td className="border border-slate-300 px-4 py-2">{Trip.TripId}</td>
                <td className="border border-slate-300 px-4 py-2">{Trip.Destination}</td>
                <td className="border border-slate-300 px-4 py-2">{Trip.StartDate}</td>
                <td className="border border-slate-300 px-4 py-2">{Trip.EndDate}</td>
                <td className="border border-slate-300 px-4 py-2">{Trip.Itinerary}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
    </>
    );
}