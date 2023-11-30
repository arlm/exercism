export const rows = (count) => {
  var response = [];

  if (!count || count < 1) { return response; }

  response.push ([1]);
  count--;

  if (count == 0) { return response; }
  
  response.push ([1, 1]);
  count--;

  if (count == 0) { return response; }
  
  while (count > 0) {
    var row = [];
    
    row.push(1);
    
    response[response.length - 1].forEach((item, index , thisRow) => row.push(index == (thisRow.length - 1) ? item : item + thisRow[index + 1]));

    response.push(row);
    
    count--;
  }
  
  return response;
};
