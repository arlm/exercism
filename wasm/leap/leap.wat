(module
  ;;
  ;; Determine if a year is a leap year
  ;;
  ;; @param {i32} year - The year to check
  ;;
  ;; @returns {i32} 1 if leap year, 0 otherwise
  ;;
  (func (export "isLeap") (param $year i32) (result i32)
    local.get $year
    i32.const 3
    i32.and
    i32.const 0
    i32.ne
    if
      i32.const 0
      return
    end
    
    local.get $year
    i32.const 100
    i32.rem_u
    i32.const 0
    i32.ne
    if
      i32.const 1
      return
    end

    local.get $year
    i32.const 400
    i32.rem_u
    i32.const 0
    i32.eq
    if
      i32.const 1
      return
    end

    i32.const 0
    return
  )
)
