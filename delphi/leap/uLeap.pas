unit uLeap;

interface
    type TYear = class(TObject)
        class function IsLeap(year: integer): boolean;
    end;

implementation

class function TYear.IsLeap(year: integer): boolean;
begin
    if (year mod 100) = 0 then
        result := (year mod 400) = 0
    else
        result := (year mod 4) = 0 ;

end;

end.
