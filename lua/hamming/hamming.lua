local Hamming = {}

function Hamming.compute(a,b)
   if #a ~= #b then
      return -1
   end

   local count = 0

   for index = 1, #a do
      if a:sub(index,index) ~= b:sub(index,index) then
         count = count + 1
      end
   end

   return count
end

return Hamming
