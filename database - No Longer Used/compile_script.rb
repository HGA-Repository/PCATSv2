require 'iconv'

class String
  def remove_non_ascii(replacement="")
    isUnicode = self.match /[\x80-\xff]/
      if isUnicode then
        c = self.gsub(/[\x80-\xff]/,replacement)
        c = c.gsub /[\000]/, ""
        Iconv.conv('us-ascii//translit', 'utf-8', c)
      else
        self
      end
  end
end



files = Dir.glob("*.sql")
files = files.select{|f| f.match /^\d+/ }

all = ""

files.each do |filename|
  all += "\n--#{filename}\n"
  file = File.open(filename, "r")
  all += file.read.remove_non_ascii + "\nGO\n\n"
end

#remove USE
all = all.gsub "USE [RSManpowerSchDb]", ""
all = all.gsub "[RSManpowerSchDb]\.", ""

all = all.gsub "USE [RSManpowerSchDb_test]", ""
all = all.gsub "[RSManpowerSchDb_test]\.", ""

all = all.gsub "USE [RSManpowerSchDb_dev]", ""
all = all.gsub "[RSManpowerSchDb_dev]\.", ""

all = all.gsub /ALTER TABLE .* SET \(LOCK_ESCALATION = TABLE\)/, ""


nums = files.map{|f| f.match(/^\d+/)[0]}

#Add starting USE
all = "USE [RSManpowerSchDb_dev]\nGO\n" + all

file = File.new("compiled_#{nums.first}-#{nums.last}.sql", "w")
file.write(all)
file.close

#puts all

