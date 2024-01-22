class AssemblyLine
  SPEED_INCREMENT = 221

  def initialize(speed)
    if speed > 10 or speed < 1
      raise 'Speed should not be above 10 or bellow 1'
    end

    @speed = speed
  end

  def production_rate_per_hour
    if @speed <= 4
      rate = 1
    elsif @speed <= 8
      rate = 0.90
    elsif @speed == 9
      rate = 0.80
    else
      rate = 0.77
    end

    return @speed * SPEED_INCREMENT * rate
  end

  def working_items_per_minute
    (production_rate_per_hour / 60).to_i
  end
end
